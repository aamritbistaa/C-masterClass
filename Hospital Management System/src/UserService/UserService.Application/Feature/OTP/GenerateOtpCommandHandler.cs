using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.OTP;

public class GenerateOtpCommandHandler : IRequestHandler<GenerateOtpCommand, ServiceResult<string>>
{
    private readonly IUserRepository _userRepo;
    private readonly IOtpRepository _otpRepo;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMailService _mailService;
    public GenerateOtpCommandHandler(IUserRepository userRepo, IOtpRepository otpRepo, IDateTimeProvider dateTimeProvider, IUnitOfWork unitOfWork, IMailService mmailService)
    {
        _userRepo = userRepo;
        _otpRepo = otpRepo;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
        _mailService = mmailService;
    }

    public async Task<ServiceResult<string>> Handle(GenerateOtpCommand request, CancellationToken cancellationToken)
    {
        Guid userId;
        if (!string.IsNullOrEmpty(request.MobileNumber))
        {
            (userId, request.Email) = await _userRepo.GetUserIdAndEmailByMobileNo(request.MobileNumber);
        }
        else
        {
            userId = await _userRepo.GetUserIdByEmail(request.Email);
        }

        var existingOtp = await _otpRepo.GetOtpByUserIdAndOtpType(userId, OTPType.Authentication);
        if (existingOtp == null)
        {
            //Generate new otp
            var otp = new EOTP
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                OTPType = OTPType.Authentication,
                AttemptCount = 0,
                FailCount = 0,
                ExpiryTime = _dateTimeProvider.CurrentDate.AddMinutes(3),
                OtpValue = await _otpRepo.GenerateOtp(OTPType.Authentication)
            };
            await _otpRepo.CreateOtp(otp);
            await _unitOfWork.SaveChangesAsync();
            // send email
            await _mailService.SendMailAsync(request.Email, "Sign up Otp", otp.OtpValue);
            return new ServiceResult<string>
            {
                Data = otp.OtpValue,
                Message = "Otp generated successfully",
                StatusCode = 201
            };
        }

        //Check fail count
        if (existingOtp.AttemptCount > 5 || existingOtp.FailCount > 5)
        {
            //Contact support
            return new ServiceResult<string>
            {
                Data = "",
                Message = "Otp limit exceeds please contact support",
                StatusCode = 201
            };
        }

        existingOtp.AttemptCount++;
        //Check if otp is expired or not
        var currentTime = _dateTimeProvider.CurrentDate;
        existingOtp.ExpiryTime = currentTime.AddMinutes(5);
        if (existingOtp.ExpiryTime > currentTime)
        {
            await _otpRepo.UpdateOtp(existingOtp);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result != 1)
            {
                return new ServiceResult<string>
                {
                    Data = "",
                    Message = "Error saving Otp",
                    StatusCode = 201
                };
            }
            await _mailService.SendMailAsync(request.Email, "Sign up Otp", existingOtp.OtpValue);
            return new ServiceResult<string>
            {
                Data = "",
                Message = "Otp has been sent.",
                StatusCode = 201
            };
        }
        existingOtp.OtpValue = await _otpRepo.GenerateOtp(OTPType.Authentication);
        await _otpRepo.UpdateOtp(existingOtp);
        var result1 = await _unitOfWork.SaveChangesAsync();
        if (result1 != 1)
        {
            return new ServiceResult<string>
            {
                Data = "",
                Message = "Error saving Otp",
                StatusCode = 201
            };
        }
        await _mailService.SendMailAsync(request.Email, "Sign up Otp", existingOtp.OtpValue);

        return new ServiceResult<string>
        {
            Data = "",
            Message = "New Otp has been sent.",
            StatusCode = 201
        };
    }
}

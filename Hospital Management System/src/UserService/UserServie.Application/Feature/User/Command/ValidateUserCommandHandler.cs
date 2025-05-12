using System;
using MediatR;
using Serilog;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.User.Command;

public class ValidateUserCommandHandler : IRequestHandler<ValidateUserCommand, ServiceResult<string>>
{
    private readonly IOtpRepository _otpRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMailService _mailService;
    public ValidateUserCommandHandler(IOtpRepository otpRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, IMailService mailService)
    {
        _otpRepository = otpRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
        _mailService = mailService;
    }

    public async Task<ServiceResult<string>> Handle(ValidateUserCommand request, CancellationToken cancellationToken)
    {
        Guid userId;
        if (!string.IsNullOrEmpty(request.MobileNumber))
        {
            (userId, request.Email) = await _userRepository.GetUserIdAndEmailByMobileNo(request.MobileNumber);
        }
        else
        {
            userId = await _userRepository.GetUserIdByEmail(request.Email);
        }

        var existingOtp = await _otpRepository.GetOtpByUserIdAndOtpType(userId, OTPType.Authentication);
        if (existingOtp.OtpValue != request.Passcode)
        {
            existingOtp.FailCount++;
            await _otpRepository.UpdateOtp(existingOtp);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceResult<string>
            {
                Message = "Wrong otp",
                Data = "",
                StatusCode = 200
            };
        }

        var currentDateTime = _dateTimeProvider.CurrentDate;
        if (existingOtp.ExpiryTime < currentDateTime)
        {
            return new ServiceResult<string>
            {
                Message = "Expired Otp",
                Data = "",
                StatusCode = 200
            };
        }

        var user = await _userRepository.GetUserById(userId);
        user.UpdatedDate = _dateTimeProvider.CurrentDate;
        user.OnBoardingStatus = OnBoardingStatus.InProgress;
        await _otpRepository.DeleteOtp(existingOtp);
        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
        await _mailService.SendMailAsync(user.Email, "Sign Up success", "User details has been successfully verified. A progess in user onboarding.");
        return new ServiceResult<string>
        {
            Message = "User validation success",
            Data = "",
            StatusCode = 200
        };
    }
}

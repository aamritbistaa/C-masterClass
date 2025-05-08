using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.User.Command;

public class GenerateOtpCommandHandler : IRequestHandler<GenerateOtpCommand>
{
    private readonly IUserRepository _userRepo;
    private readonly IOtpRepository _otpRepo;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;
    public GenerateOtpCommandHandler(IUserRepository userRepo, IOtpRepository otpRepo, IDateTimeProvider dateTimeProvider, IUnitOfWork unitOfWork)
    {
        _userRepo = userRepo;
        _otpRepo = otpRepo;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(GenerateOtpCommand request, CancellationToken cancellationToken)
    {
        Guid userId;
        if (!string.IsNullOrEmpty(request.MobileNumber))
        {
            userId = await _userRepo.GetUserIdByMobileNo(request.MobileNumber);
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
                ExpiryTime = _dateTimeProvider.CurrentDate.AddMinutes(5),
                OtpValue = "ABC2123"
            };
            await _otpRepo.CreateOtp(otp);
            await _unitOfWork.SaveChangesAsync();
            //! Todo : send email
            return;
        }

        //Check fail count
        if (existingOtp.FailCount > 3)
        {
            //Contact support

            return;
        }


        //Check if otp is expired or not
        var currentTime = _dateTimeProvider.CurrentDate;

        if (currentTime > existingOtp.ExpiryTime)
        {

        }

        existingOtp.AttemptCount++;
        existingOtp.OtpValue = "ABC2123";




        throw new NotImplementedException();
    }
}

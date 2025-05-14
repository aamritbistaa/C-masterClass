using System;
using System.Security.Cryptography;
using MediatR;
using Serilog;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Enum;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.User.Command;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResult<string>>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;
    private readonly IOtpRepository _otpRepository;
    private readonly IMailService _mailService;
    public CreateUserCommandHandler(IDateTimeProvider dateTimeProvider, IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger logger, IOtpRepository otpRepository, IMailService mailService)
    {
        _dateTimeProvider = dateTimeProvider;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _otpRepository = otpRepository;
        _mailService = mailService;
    }

    public async Task<ServiceResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userModel = new EUser
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Email = request.Email,
                CreatedDate = _dateTimeProvider.CurrentDate,
                CreatedBy = request.ActionBy,
                MobileNumber = request.MobileNumber,
                Id = Guid.NewGuid(),
                Role = (UserRole)request.Role,
                OnBoardingStatus = OnBoardingStatus.NotStarted
            };
            await _userRepository.AddAsync(userModel);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result == 1)
            {
                _logger.Information("Registered successfully");
                await GeneratePassCodeAndSendEmail(userModel.Id, userModel.Email);
                return new ServiceResult<string>
                {
                    Data = userModel.Id.ToString(),
                    Message = "Regitered successfully",
                    StatusCode = 201
                };
            }
            else
            {
                _logger.Error("Error adding user");
                throw new Exception("Cannot add");
            }
        }
        catch (Exception ex)
        {
            _logger.Fatal(ex.Message);
            throw;
        }
    }
    private async Task GeneratePassCodeAndSendEmail(Guid userId, string Email)
    {
        //Some passcode geenration Logic

        var otp = new EOTP
        {
            AttemptCount = 0,
            FailCount = 0,
            ExpiryTime = _dateTimeProvider.CurrentDate.AddMinutes(5),
            OTPType = OTPType.Authentication,
            UserId = userId,
            OtpValue = "1111"
        };
        await _otpRepository.CreateOtp(otp);
        await _unitOfWork.SaveChangesAsync();

        //Send email
        await _mailService.SendMailAsync(Email, "Sign in OTP", otp.OtpValue);
    }
}

using System;
using System.Security.Cryptography;
using MediatR;
using Serilog;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Enum;
using UserService.Domain.Service.Interface;

namespace UserServie.Application.Feature.User.Command;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;
    private readonly IOtpRepository _otpRepository;
    public CreateUserCommandHandler(IDateTimeProvider dateTimeProvider, IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger logger, IOtpRepository otpRepository)
    {
        _dateTimeProvider = dateTimeProvider;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _otpRepository = otpRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
                CreatedBy = Guid.Empty,
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
                return userModel.Id;
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
            UserId = userId
        };
        await _otpRepository.CreateOtp(otp);
        await _unitOfWork.SaveChangesAsync();

        //Send email
    }
}

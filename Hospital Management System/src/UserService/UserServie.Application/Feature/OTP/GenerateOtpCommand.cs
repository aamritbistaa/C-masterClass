using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;

namespace UserServie.Application.Feature.OTP;

public class GenerateOtpCommand : IRequest<ServiceResult<string>>
{
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public OTPType OTPType { get; set; }
}

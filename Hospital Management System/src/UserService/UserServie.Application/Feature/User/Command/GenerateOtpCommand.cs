using System;
using MediatR;
using UserService.Domain.Abstraction;

namespace UserServie.Application.Feature.User.Command;

public class GenerateOtpCommand : IRequest<ServiceResult<string>>
{
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}

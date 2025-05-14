using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserServie.Application.Common;

namespace UserServie.Application.Feature.User.Command;

public class ValidateUserCommand : IRequest<ServiceResult<string>>
{
    public string Passcode { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}

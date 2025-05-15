using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserServie.Application.Common;

namespace UserServie.Application.Feature.User.Command;

public class ValidateUserCommand : CommonCommandParameter, IRequest<ServiceResult<string>>
{
    public Guid UserId { get; set; }
    public string Passcode { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}

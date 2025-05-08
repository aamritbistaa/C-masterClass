using System;
using MediatR;

namespace UserServie.Application.Feature.User.Command;

public class ValidateUserCommand : IRequest<bool>
{
    public string Passcode { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}

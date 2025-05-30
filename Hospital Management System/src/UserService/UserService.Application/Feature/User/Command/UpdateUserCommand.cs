using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserServie.Application.Common;

namespace UserService.Application.Feature.User.Command;

public class UpdateUserCommand : CommonCommandParameter, IRequest<ServiceResult<string>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public int Role { get; set; }
}

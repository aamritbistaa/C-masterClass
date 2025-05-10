using System;
using MediatR;
using UserService.Domain.Abstraction;

namespace UserServie.Application.Feature.User.Command;

public class CreateUserCommand : IRequest<ServiceResult<string>>
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public int Role { get; set; }
}

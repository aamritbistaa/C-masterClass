using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserServie.Application.Common;

namespace UserService.Application.Feature.User.Command;

public class AddAdditionalUserCommand : CommonCommandParameter, IRequest<ServiceResult<string>>
{
    public Guid UserId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodGroup BloodGroup { get; set; }
    public string AdditionalContactNumber { get; set; }
}

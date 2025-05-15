using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserServie.Application.Feature.User.Query;

namespace UserService.Application.Feature.User.Query;

public class GetUserByIdQuery : IRequest<ServiceResult<GetUserResponse>>
{
    public Guid UserId { get; set; }
}

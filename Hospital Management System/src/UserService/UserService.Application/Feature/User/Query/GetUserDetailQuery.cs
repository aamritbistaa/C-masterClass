using System;
using MediatR;
using UserService.Domain.Abstraction;

namespace UserService.Application.Feature.User.Query;

public class GetUserDetailQuery : IRequest<ServiceResult<GetUserDetailResponse>>
{
    public Guid UserId { get; set; }
}

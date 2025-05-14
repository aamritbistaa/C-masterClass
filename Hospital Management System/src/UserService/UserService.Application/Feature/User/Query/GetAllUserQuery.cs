using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserServie.Application.Common;

namespace UserServie.Application.Feature.User.Query;

public class GetAllUserQuery : CommonListFilterParameter, IRequest<ServiceResult<List<GetAllUserResponse>>>
{
    public OnBoardingStatus OnBoardingStatus { get; set; }
}

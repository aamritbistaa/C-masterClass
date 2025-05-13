using System;
using MediatR;
using UserService.Domain.Entity;

namespace UserServie.Application.Feature.User.Query;

public class GetAllUserQuery : IRequest<List<GetAllUserResponse>>
{
    public OnBoardingStatus OnBoardingStatus { get; set; }
}

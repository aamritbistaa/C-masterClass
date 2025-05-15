using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Enum;
using UserService.Domain.Service.Interface;
using UserServie.Application.Common;
using UserServie.Application.Feature.User.Query;

namespace UserService.Application.Feature.User.Query;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ServiceResult<GetUserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    async Task<ServiceResult<GetUserResponse>> IRequestHandler<GetUserByIdQuery, ServiceResult<GetUserResponse>>.Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userDetail = await _userRepository.GetUserById(request.UserId);
        if (userDetail == null)
        {
            return new ServiceResult<GetUserResponse>()
            {
                Message = "User not found",
                StatusCode = 200,
                Data = new GetUserResponse()
            };
        }
        var responseData = new GetUserResponse
        {
            Id = userDetail.Id,
            Email = userDetail.Email,
            FullName = CommonClass.GetName(userDetail.FirstName, userDetail.MiddleName, userDetail.LastName),
            MobileNumber = userDetail.MobileNumber,
            Role = ((UserRole)userDetail.Role).ToString()
        };
        return new ServiceResult<GetUserResponse>()
        {
            Data = responseData,
            Message = "Data fetched successfully",
            StatusCode = 200
        };
    }
}

using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;

namespace UserService.Application.Feature.User.Query;

public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, ServiceResult<GetUserDetailResponse>>
{
    private readonly IUserDetailRepository _userDetailRepository;

    public GetUserDetailQueryHandler(IUserDetailRepository userDetailRepository)
    {
        _userDetailRepository = userDetailRepository;
    }

    public async Task<ServiceResult<GetUserDetailResponse>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        var data = await _userDetailRepository.GetUserDetailByUserId(request.UserId);
        if (data == null)
        {
            return new ServiceResult<GetUserDetailResponse>()
            {
                Message = "Data not found",
                StatusCode = 200
            };
        }
        var response = new GetUserDetailResponse()
        {
            AdditionalContactNumber = data.AdditionalContactNumber,
            BloodGroup = ((BloodGroup)data.BloodGroup).ToString(),
            DateOfBirth = data.DateOfBirth
        };
        return new ServiceResult<GetUserDetailResponse>()
        {
            Data = response,
            Message = "Data fetched successfully",
            StatusCode = 200
        };
    }
}

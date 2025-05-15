using System;
using MediatR;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Enum;
using UserService.Domain.Service.Interface;
using UserServie.Application.Common;

namespace UserServie.Application.Feature.User.Query;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ServiceResult<List<GetUserResponse>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ServiceResult<List<GetUserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var data = await _userRepository.GetAllUserByStatus(status: request.OnBoardingStatus, pageNo: request.PageNo, pageSize: request.PageSize);

        var response = from item in data
                       select new GetUserResponse
                       {
                           Id = item.Id,
                           FullName = CommonClass.GetName(item.FirstName, item.MiddleName, item.LastName),
                           Email = item.Email,
                           MobileNumber = item.MobileNumber,
                           Role = Enum.GetName<UserRole>(item.Role),
                       };
        return new ServiceResult<List<GetUserResponse>>
        {
            Data = response.ToList(),
            Message = "Data fetched successfully",
            StatusCode = 200
        };
    }
}

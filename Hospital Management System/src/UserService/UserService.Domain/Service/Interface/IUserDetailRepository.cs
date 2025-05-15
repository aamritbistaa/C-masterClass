using System;
using UserService.Domain.Entity;

namespace UserService.Domain.Service.Interface;

public interface IUserDetailRepository
{
    Task AddUserDetail(EUserDetail request);
    Task UpdateUserDetail(EUserDetail request);
    Task<EUserDetail> GetUserDetailByUserId(Guid userId);
    Task<EUserDetail> GetById(Guid Id);
}

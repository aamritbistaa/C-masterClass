using System;
using UserService.Domain.Entity;

namespace UserService.Domain.Service.Interface;

public interface IUserDetailRepository
{
    Task AddUserDetail(EUserDetail request);
}

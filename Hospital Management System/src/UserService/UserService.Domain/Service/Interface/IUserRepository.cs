using System;
using UserService.Domain.Entity;

namespace UserService.Domain.Service.Interface;

public interface IUserRepository
{
    Task AddAsync(EUser user);
}

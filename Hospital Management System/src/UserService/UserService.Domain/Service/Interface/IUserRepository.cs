using System;
using UserService.Domain.Entity;

namespace UserService.Domain.Service.Interface;

public interface IUserRepository
{
    Task AddAsync(EUser user);
    Task UpdateAsync(EUser user);
    Task<Guid> GetUserIdByEmail(string email);
    Task<(Guid, string)> GetUserIdAndEmailByMobileNo(string mobileNumber);
    Task<EUser> GetUserById(Guid id);
}

using System;
using UserService.Domain.Entity;

namespace UserService.Domain.Service.Interface;

public interface IUserRepository
{
    Task AddAsync(EUser user);
    Task<Guid> GetUserIdByEmail(string email);
    Task<(Guid, string)> GetUserIdAndEmailByMobileNo(string mobileNumber);
}

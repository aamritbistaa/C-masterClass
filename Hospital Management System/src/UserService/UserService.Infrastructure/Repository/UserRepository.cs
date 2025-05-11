using System;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repository;

public class UserRepository : Repository<EUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddAsync(EUser user)
    {
        await base.AddAsync(user);
    }

    public async Task<Guid> GetUserIdByEmail(string email)
    {
        var data = await base.ListAsync();
        var user = data.FirstOrDefault(x => x.Email == email && x.IsDeleted == false);
        return user.Id;
    }

    public async Task<(Guid, string)> GetUserIdAndEmailByMobileNo(string mobileNumber)
    {
        var data = await base.ListAsync();
        var user = data.FirstOrDefault(x => x.MobileNumber == mobileNumber && !x.IsDeleted);
        return (user.Id, user.Email);
    }
}

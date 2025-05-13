using System;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
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
    public async Task UpdateAsync(EUser user)
    {
        await base.UpdateAsync(user);
    }

    public async Task<Guid> GetUserIdByEmail(string email)
    {
        var user = await base.AsQuerable().FirstOrDefaultAsync(x => x.Email == email && x.IsDeleted == false);
        return user.Id;
    }

    public async Task<(Guid, string)> GetUserIdAndEmailByMobileNo(string mobileNumber)
    {
        var user = await base.AsQuerable().FirstOrDefaultAsync(x => x.MobileNumber == mobileNumber && !x.IsDeleted);
        return (user.Id, user.Email);
    }
    public async Task<EUser> GetUserById(Guid id)
    {
        var user = await base.AsQuerable().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        return user;
    }
    public async Task<List<EUser>> GetAllUserByStatus(OnBoardingStatus status, int pageNo, int pageSize)
    {
        var data = await base.AsQuerable().Where(x => x.OnBoardingStatus == status).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        return data;
    }
}

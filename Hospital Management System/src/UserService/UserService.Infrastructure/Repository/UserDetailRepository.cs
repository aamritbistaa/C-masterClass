using System;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repository;

public class UserDetailRepository : Repository<EUserDetail>, IUserDetailRepository
{
    public UserDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddUserDetail(EUserDetail request)
    {
        await base.AddAsync(request);
    }

    public async Task<EUserDetail> GetUserDetailByUserId(Guid userId)
    {
        var data = await base.AsQuerable().FirstOrDefaultAsync(x => x.UserId == userId && !x.IsDeleted);
        return data;
    }

    public async Task<EUserDetail> GetById(Guid Id)
    {
        var data = await base.AsQuerable().FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        return data;
    }

    public async Task UpdateUserDetail(EUserDetail request)
    {
        await base.UpdateAsync(request);
    }
}

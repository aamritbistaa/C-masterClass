using System;
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
}

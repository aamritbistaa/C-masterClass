using System;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repository;

public class UserDocumentRepository : Repository<EUserDocument>, IUserDocumentRepository
{
    public UserDocumentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    public async Task AddUserDocument(EUserDocument reqeust)
    {
        await base.AddAsync(reqeust);
    }
    public async Task UpdateUserDocument(EUserDocument reqeust)
    {
        await base.UpdateAsync(reqeust);
    }
    public async Task<List<EUserDocument>> GetAllDocumentByUserId(Guid userId)
    {
        var data = await base.AsQuerable().Where(x => x.UserId == userId && !x.IsDeleted).ToListAsync();
        return data;
    }
    public async Task<EUserDocument> GetDocumentId(Guid Id)
    {
        var data = await base.AsQuerable().FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        return data;
    }
}

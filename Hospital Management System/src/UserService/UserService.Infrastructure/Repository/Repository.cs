using System;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repository;

public abstract class Repository<T> where T : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    protected async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Abstraction;
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
    protected async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
    protected async Task<List<T>> ListAsync(int pageNo, int pageSize)
    {
        return await _dbContext.Set<T>().Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
    }
    protected IQueryable<T> AsQuerable()
    {
        return _dbContext.Set<T>().AsQueryable();
    }
    protected async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
}

﻿using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Domain.Repository
{
    public interface IEmployeeRepository<t>
    {
        Task<t> FindAsync(int id);
        Task<List<t>> ListAsync();
        Task<t> AddAsync(t model);
        Task<bool> UpdateAsync(t model);
        Task<int> RemoveAsync(t model);
        Task<bool> AddRangeAsync(List<t> model);
        Task<bool> RemoveRangeAsync(List<t> model);
    }
}

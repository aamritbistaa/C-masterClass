using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Domain.Service.Interface;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class EmployeeRepository<t> : IEmployeeRepository<t>, IDisposable where t : class
    {
        private readonly AppDbContext db;
        private readonly DbSet<t> entity;
        public EmployeeRepository()
        {
            db = new AppDbContext();
            entity = db.Set<t>();
        }
        public EmployeeRepository(AppDbContext db)
        {
            this.db = db;
            entity = db.Set<t>();
        }

        public async Task<List<t>> ListAsync()
        {
            //AsNoTracking, the change tracking mechanism is disabled, resulting in better
            //performance and reduced memory usage, especially in read - only scenarios
            var result =  await db.Set<t>().AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<t> FindAsync(int id)
        {
            var result = await db.Set<t>().FindAsync(id);
            return result;
        }
        public async Task<t> AddAsync(t model)
        {
            if(model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            try
            {
                // all the tracked entities are detached, and their state is reset.
                // This can be useful in certain scenarios where you want to start fresh without any tracked entities
                db.ChangeTracker.Clear();

                var output = await db.Set<t>().AddAsync(model);
                var result = output.Entity;
                await db.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateAsync(t model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            try
            {
                db.ChangeTracker.Clear();
                var output = db.Set<t>().Update(model);
                var result = output.Entity;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public async Task<int> RemoveAsync(t model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            try
            {
                db.ChangeTracker.Clear();
                var output = db.Set<t>().Remove(model);
                var result = output.Entity;
                //returns PrimaryKey
                return await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> AddRangeAsync(List<t> model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            try
            {
                db.ChangeTracker.Clear();
                var output =  db.Set<t>().AddRangeAsync(model);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public async Task<bool> RemoveRangeAsync(List<t> model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            try
            {
                db.ChangeTracker.Clear();
                db.Set<t>().RemoveRange(model);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }        
    }
}

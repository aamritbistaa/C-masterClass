using CleanArchitecture.Application.Repository;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class EmployeeRepository<t> : IEmployeeRepository<t>, IDisposable where t : class
    {
        AppDbContext db;
        DbSet<t> entity;
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
            return await entity.AsNoTracking().ToListAsync();
        }
        public async Task<t> UpdateAsync(t model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            try
            {
                db.ChangeTracker.Clear();
                var newEntity = entity.Update(model);
                var newEntityToRet = newEntity.Entity;
                db.SaveChanges();
                return newEntityToRet;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw;
            }
        }
        public async Task<t> FindAsync(int id)
        {
            var newEntity = await entity.FindAsync(id);
            return newEntity;
        }
        public async Task<bool> AddRangeAsync(List<t> model)
        {
            try
            {
                await entity.AddRangeAsync(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception wx)
            {
                return false;
            }
        }
        public async Task<bool> RemoveRangeAsync(List<t> model)
        {
            try
            {
                entity.RemoveRange(model);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception wx)
            {
                return false;
            }
        }

        public async Task<t> AddAsync(t model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            try
            {
                db.ChangeTracker.Clear();
                var newEntity = await entity.AddAsync(model);
                var newEntityToRet = newEntity.Entity;
                db.SaveChanges();

                return newEntityToRet;
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw;
            }
        }

        public async Task<int> RemoveAsync(t model)
        {
            db.ChangeTracker.Clear();
            entity.Remove(model);
            return await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            //your memory
            //your connection
            //place to clean
        }
    }
}

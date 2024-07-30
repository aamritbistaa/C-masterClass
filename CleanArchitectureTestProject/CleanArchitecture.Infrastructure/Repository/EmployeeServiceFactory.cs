using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Domain.Service.Interface;
using CleanArchitecture.Infrastructure.Context;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class EmployeeServiceFactory : IDisposable, IEmployeeServiceFactory
    {
        public AppDbContext db;

        public EmployeeServiceFactory()
        {
            db = new AppDbContext();
        }
        public EmployeeServiceFactory(AppDbContext db)
        {
            this.db = db;
        }
        public void Dispose()
        {
        }
        public IEmployeeRepository<t> GetInstance<t>() where t : class
        {
            return new EmployeeRepository<t>(db);
        }
        public void BeginTransaction()
        {
            db.Database.BeginTransaction();
        }
        public void RollBack()
        {
            db.Database.RollbackTransaction();
        }
        public void CommitTransaction()
        {
            db.Database.CommitTransaction();
        }
        public void WriteLog(string message, object exception, string v)
        {

        }
    }
}

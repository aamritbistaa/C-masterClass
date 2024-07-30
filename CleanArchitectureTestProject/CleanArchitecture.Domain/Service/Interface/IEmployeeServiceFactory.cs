using CleanArchitecture.Domain.Repository;

namespace CleanArchitecture.Domain.Service.Interface
{
    public interface IEmployeeServiceFactory
    {
        IEmployeeRepository<t> GetInstance<t>() where t : class;
        
        void BeginTransaction();

        void RollBack();

        void CommitTransaction();
    }
}

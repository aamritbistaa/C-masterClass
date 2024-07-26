using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.Manager.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(CreateEmployeeRequest request);
        Task<Employee> UpdateEmployee(UpdateEmployeeRequest request);
        Task<Employee> DeleteEmployee(int id);  
    }
}

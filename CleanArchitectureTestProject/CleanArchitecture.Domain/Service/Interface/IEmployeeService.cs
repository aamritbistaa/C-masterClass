using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Service.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee request);
        Task<bool> UpdateEmployee(Employee request);
    }
}

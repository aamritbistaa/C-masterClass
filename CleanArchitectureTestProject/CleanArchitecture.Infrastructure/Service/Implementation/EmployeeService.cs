using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeServiceFactory _factory;

        public EmployeeService(IEmployeeServiceFactory factory)
        {
            _factory = factory;
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
            var result = await _factory.GetInstance<Employee>().ListAsync();
            return result;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            var result = await _factory.GetInstance<Employee>().FindAsync(id);
            return result;
        }
        public async Task<Employee> AddEmployee(Employee request)
        {
            var result = await _factory.GetInstance<Employee>().AddAsync(request);
            return result;
        }
        public async Task<bool> UpdateEmployee(Employee request)
        {
            var result = await _factory.GetInstance<Employee>().UpdateAsync(request);
            return result;
        }
    }
}

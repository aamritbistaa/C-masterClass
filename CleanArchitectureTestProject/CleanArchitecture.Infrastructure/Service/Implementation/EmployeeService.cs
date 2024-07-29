using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.Entity;
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
        private readonly IEmployeeRepository<Employee> _employeeRepository;

        public EmployeeService(IEmployeeRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            var result = await _employeeRepository.ListAsync();
            return result;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            var result = await _employeeRepository.FindAsync(id);
            return result;
        }
        public async Task<Employee> AddEmployee(Employee request)
        {
            var result = await _employeeRepository.AddAsync(request);
            return result;
        }
        public async Task<bool> UpdateEmployee(Employee request)
        {
            var result = await _employeeRepository.UpdateAsync(request);
            return result;
        }
    }
}

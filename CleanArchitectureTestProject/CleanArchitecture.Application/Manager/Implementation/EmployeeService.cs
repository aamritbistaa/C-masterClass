using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Manager.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository<Employee> _employeeRepository;
        public EmployeeService(IEmployeeRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> AddEmployee(CreateEmployeeRequest request)
        {
            var item = new Employee
            {
                Name = request.Name,
                Age = request.Age,
                Title = request.Title
            };
            var result = await _employeeRepository.AddAsync(item);
            return result;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var item = await _employeeRepository.FindAsync(id);
            if (item == null)
            {
                return null;
            }
            item.IsDeleted = true;
            await _employeeRepository.UpdateAsync(item);
            return item;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            var item = await _employeeRepository.ListAsync();
            return item;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var item = await _employeeRepository.FindAsync(id);
            return item;
        }
        public async Task<Employee> UpdateEmployee(UpdateEmployeeRequest request)
        {
            var item = await _employeeRepository.FindAsync(request.Id);

            if (item == null)
            {
                return null;
            }
            item.Name = request.Name;
            item.Age = request.Age;
            item.Title = request.Title;

            await _employeeRepository.UpdateAsync(item);
            return item;
        }
    }
}

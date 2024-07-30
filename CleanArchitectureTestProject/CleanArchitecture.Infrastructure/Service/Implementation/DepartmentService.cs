using CleanArchitecture.Application.Manager.Interface;
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
    public class DepartmentService: IDepartmentService
    {
        //private readonly IEmployeeRepository<Department> _departmentRepository;
        //public DepartmentService(IEmployeeRepository<Department> departmentRepository)
        //{
        //    _departmentRepository = departmentRepository;
        //}
        private readonly IEmployeeServiceFactory _factory;

        public DepartmentService(IEmployeeServiceFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<Department>> GetAllDepartment()
        {
            var result = await _factory.GetInstance<Department>().ListAsync();
            //var result = await _departmentRepository.ListAsync();
            return result;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var result = await _factory.GetInstance<Department>().FindAsync(id);
            //var result = await _departmentRepository.FindAsync(id);
            return result;
        }
        public async Task<Department> AddDepartment(Department request)
        {
            var result = await _factory.GetInstance<Department>().AddAsync(request);
            //var result = await _departmentRepository.AddAsync(request);
            return result;
        }
        public async Task<bool> UpdateDepartment(Department request)
        {
            var result = await _factory.GetInstance<Department>().UpdateAsync(request);
            //var result = await _departmentRepository.UpdateAsync(request);
            return result;
        }
    }
}

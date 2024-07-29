using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Service.Interface
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartment();
        Task<Department> GetDepartmentById(int id);
        Task<Department> AddDepartment(Department request);
        Task<bool> UpdateDepartment(Department request);
    }
}

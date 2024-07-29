using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Interface
{
    public interface IDepartmentManager
    {
        Task<ServiceResult<List<Department>>> GetAllDepartment();
        Task<ServiceResult<Department>> GetDepartmentById(int id);
        Task<ServiceResult<Department>> AddDepartment(CreateDepartmentRequest request);
        Task<ServiceResult<bool>> UpdateDepartment(UpdateDepartmentRequest request);
        Task<ServiceResult<bool>> DeleteDepartment(int id);
    }
}

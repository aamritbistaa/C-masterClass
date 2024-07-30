using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Domain.Entity;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Interface
{
    public interface IEmployeeManager
    {
        Task<ServiceResult<List<EmployeeResponse>>> GetAllEmployees();
        Task<ServiceResult<EmployeeResponse>> GetEmployeeById(int id);
        Task<ServiceResult<EmployeeResponse>> AddEmployee(CreateEmployeeRequest request);
        Task<ServiceResult<bool>> UpdateEmployee(UpdateEmployeeRequest request);
        Task<ServiceResult<bool>> DeleteEmployee(int id);
    }
}

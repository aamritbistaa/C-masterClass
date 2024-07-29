using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Domain.Entity;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Interface
{
    public interface IEmployeeManager
    {
        Task<ServiceResult<List<Employee>>> GetAllEmployees();
        Task<ServiceResult<Employee>> GetEmployeeById(int id);
        Task<ServiceResult<Employee>> AddEmployee(CreateEmployeeRequest request);
        Task<ServiceResult<Employee>> UpdateEmployee(UpdateEmployeeRequest request);
        Task<ServiceResult<bool>> DeleteEmployee(int id);
    }
}

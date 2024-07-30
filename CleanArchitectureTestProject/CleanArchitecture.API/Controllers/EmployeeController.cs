using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        [HttpGet("GetAllEmployee")]
        public async Task<ServiceResult<List<EmployeeResponse>>> GetAllEmployee()
        {
            var result =await _employeeManager.GetAllEmployees();
            return result;
        }
        [HttpGet("GetEmployeeById")]
        public async Task<ServiceResult<EmployeeResponse>> GetEmployeeById(int id)
        {
            var result = await _employeeManager.GetEmployeeById(id);
            return result;
        }
        [HttpPost("AddEmployee")]
        public async Task<ServiceResult<EmployeeResponse>> AddEmployee(CreateEmployeeRequest request)
        {
            var result = await _employeeManager.AddEmployee(request);
            return result;
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ServiceResult<bool>> UpdateEmployee(UpdateEmployeeRequest request)
        {
            var result = await _employeeManager.UpdateEmployee(request);
            return result;
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<ServiceResult<bool>> DeleteEmployee(int id)
        {
            var result = await _employeeManager.DeleteEmployee(id);
            return result;
        }
    }
}

using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetAllEmployee")]
        public async Task<List<Employee>> GetAllEmployee()
        {
            var result =await _employeeService.GetAllEmployees();
            return result;
        }
        [HttpGet("GetEmployeeById")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployeeById(id);
            return result;
        }
        [HttpPost("AddEmployee")]
        public async Task<Employee> AddEmployee(CreateEmployeeRequest request)
        {
            var result = await _employeeService.AddEmployee(request);
            return result;
        }
        [HttpPut("UpdateEmployee")]
        public async Task<Employee> UpdateEmployee(UpdateEmployeeRequest request)
        {
            var result = await _employeeService.UpdateEmployee(request);
            return result;
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<Employee> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            return result;
        }

    }
}

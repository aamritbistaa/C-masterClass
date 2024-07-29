using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentManager _departmentManager;
        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }
        [HttpGet("GetAllDepartment")]
        public async Task<ServiceResult<List<Department>>> GetAllDepartment()
        {
            var result = await _departmentManager.GetAllDepartment();
            return result;
        }
        [HttpGet("GetDepartmentById")]
        public async Task<ServiceResult<Department>> GetDepartmentById(int id)
        {
            var result = await _departmentManager.GetDepartmentById(id);
            return result;
        }
        [HttpPost("AddDepartment")]
        public async Task<ServiceResult<Department>> AddDepartment(CreateDepartmentRequest request)
        {
            var result = await _departmentManager.AddDepartment(request);
            return result;
        }
        [HttpPut("UpdateDepartment")]
        public async Task<ServiceResult<bool>> UpdateDepartment(UpdateDepartmentRequest request)
        {
            var result = await _departmentManager.UpdateDepartment(request);
            return result;
        }
        [HttpDelete("DeleteDepartment")]
        public async Task<ServiceResult<bool>> DeleteDepartment(int id)
        {
            var result = await _departmentManager.DeleteDepartment(id);
            return result;
        }
    }
}

using EmployeeMS.AppDbContext;
using EmployeeMS.Dto.Request;
using EmployeeMS.Dto.Response;
using EmployeeMS.Mapper;
using EmployeeMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EmployeeMS.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllDepartment")]
        public async Task<List<DepartmentResponse>> GetAllDepartment()
        {
            var depts = _context.Departments;
            var response =
                (from item in depts
                where item.IsDeleted == false
                select Mappers.DepartmentToDepartementResponseMapper(item)
                ).ToList();

            return response;
        }

        [HttpGet("GetDepartmentById")]
        public async Task<DepartmentResponse> GetDepartmentById(int Id)
        {
            var item =  await _context.Departments.FindAsync(Id);
            var response = Mappers.DepartmentToDepartementResponseMapper(item);
            return response;
        }

        [HttpPost("CreateDepartment")]
        public async Task<DepartmentResponse> AddDepartment(string Name)
        {
            var newDepartment = new Department
            {
                Name = Name,
            };
            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            var response = Mappers.DepartmentToDepartementResponseMapper(newDepartment);
            return response;
        }

        [HttpPut("UpdateDepartment")]
        public async Task<DepartmentResponse?> UpdateDepartment(UpdateDepartmentRequest request)
        {
            var item = await _context.Departments.FindAsync(request.Id);
            if (item == null)
            {
                return null;
            }
            item.Name = request.Name;
            _context.Departments.Update(item);
            await _context.SaveChangesAsync();

            var response = Mappers.DepartmentToDepartementResponseMapper(item);
            return response;
        }

        [HttpDelete]
        public async Task<DepartmentResponse?> DeleteDepartment(int id)
        {
            var item = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return null;
            }
            item.IsDeleted = true;
            _context.Departments.Update(item);
            await _context.SaveChangesAsync();

            var response = Mappers.DepartmentToDepartementResponseMapper(item);
            return response;
        }
    }
}

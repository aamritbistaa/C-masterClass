using EmployeeMS.AppDbContext;
using EmployeeMS.Dto.Request;
using EmployeeMS.Dto.Response;
using EmployeeMS.Mapper;
using EmployeeMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeMS.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllEmployee")]
        public async Task<List<EmployeeResponse>?> GetAllEmployee()
        {
            var emp = await _context.Employees.ToListAsync();

            var response = (from item in emp
                            where item.IsDeleted == false
                            select Mappers.EmployeeToEmployeeResponseMapper(item)
                            ).ToList();
            return response;
        }
        [HttpGet("GetEmployeeById")]
        public async Task<EmployeeResponse?> GetEmployeeById(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
            {
                return null;
            }
            var response = Mappers.EmployeeToEmployeeResponseMapper(emp);

            return response;
        }
        [HttpPost("CreateEmployee")]
        public async Task<EmployeeResponse?> CreateEmployee(CreateEmployeeRequest request)
        {
            var emp = _context.Employees;
            var data = new Employee
            {
                Position = request.Position,
                Salary = request.Salary,
                DeptId = request?.DeptId,
                UserId = request?.UserId
            };

            await emp.AddAsync(data);
            await _context.SaveChangesAsync();

            var response = Mappers.EmployeeToEmployeeResponseMapper(data);
            return response;
        }
        [HttpPost("UpdateEmployee")]
        public async Task<EmployeeResponse?> UpdateEmployee(UpdateEmployeeRequest request)
        {
            var emp = _context.Employees;

            var data = await emp.FindAsync(request.Id);
            if (data == null)
            {
                return null;
            }
            data.Position = request.Position;
            data.Salary = request.Salary;
            data.DeptId = request.DeptId;
            data.UserId = request.UserId;
            emp.Update(data);
            await _context.SaveChangesAsync();

            var response = Mappers.EmployeeToEmployeeResponseMapper(data);
            return response;
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<EmployeeResponse?> DeleteEmployee(int id)
        {
            var emp = _context.Employees;
            var data = await emp.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            data.IsDeleted = true;
            emp.Update(data);
            await _context.SaveChangesAsync();

            var response = Mappers.EmployeeToEmployeeResponseMapper(data);
            return response;
        }
    }
}

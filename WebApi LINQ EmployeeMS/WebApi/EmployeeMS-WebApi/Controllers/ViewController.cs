using EmployeeMS.AppDbContext;
using EmployeeMS.Dto.Response;
using EmployeeMS.Mapper;
using EmployeeMS.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace EmployeeMS.Controllers
{
    [Route("api/v1/[controller]")]
    public class ViewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetEmployeeRecordById")]
        public ActionResult GetEmployeeRecordById(int Id)
        {
            var emp = _context.Employees.ToList();
            var usr = _context.Users.ToList();
            var addr = _context.Addresses.ToList();
            var dept = _context.Departments.ToList();
            var atten = _context.Attendances.ToList();

            var allAttendance =
                (from item in atten
                 where item.EmployeeId == Id
                 select Mappers.AttendanceToAttendanceResponseMapper(item)
                 ).ToList();

            var empDetails =
                (from item in emp
                 where item.Id == Id
                 select item).FirstOrDefault();
            
            var userDetails =
                (from item in usr
                 where item.Id == empDetails.UserId
                 select item).FirstOrDefault();

            var deptDeptails =
                (from item in dept
                 where item.Id == empDetails.DeptId
                 select item).FirstOrDefault();

            var res = new
            {
                Name = userDetails.Name,
                Email = userDetails.Email,
                PhoneNumber = userDetails.PhoneNumber,
                DateOfBirth = userDetails.DateOfBirth,
                Salary = empDetails.Salary,
                Position = empDetails.Position,
                DepartmentName = deptDeptails.Name,
                Attendance = allAttendance,
            };
            return Ok(res);
        }
        [HttpGet("GetAllEmployeeByDepartment")]
        public ActionResult GetAllEmployeeByDepartment()
        {
            var emp = _context.Employees.ToList();
            var usr = _context.Users.ToList();
            var addr = _context.Addresses.ToList();
            var dept = _context.Departments.ToList();

            var datas =
                (from e in emp
                 join u in usr
                 on e.UserId equals u.Id
                 join a in addr
                 on u.AddressId equals a.Id
                 join d in dept
                 on e.DeptId equals d.Id
                 select new
                 {
                     e.Id,
                     u.Name,
                     u.Email,
                     u.PhoneNumber,
                     u.DateOfBirth,
                     e.Salary,
                     e.Position,
                     a.Country,
                     a.City,
                     DepartmentName = d.Name
                 }).ToList();

            var response =
                (from item in datas
                 group item by item.DepartmentName into groups
                 select new
                 {
                     Department = groups.Key,
                     people = (from it in groups
                               select new
                               {
                                   it.Id,
                                   it.Name,
                                   it.Email,
                                   it.PhoneNumber,
                                   it.DateOfBirth,
                                   it.Salary,
                                   it.Position,
                                   it.Country,
                                   it.City,
                                   it.DepartmentName
                               }).ToList()
                 }).ToList();
            return Ok(response);


        }

        [HttpGet("GetCompleteEmployeeRecord")]
        public ActionResult GetCompleteEmployeeRecord()
        {
            var emp = _context.Employees.ToList();
            var usr = _context.Users.ToList();
            var addr = _context.Addresses.ToList();
            var dept = _context.Departments.ToList();
            var atten = _context.Attendances.ToList();

            var userRecord =
                   (from e in emp
                    join u in usr 
                    on e.UserId equals u.Id
                    join a in addr
                    on u.AddressId equals a.Id
                    join d in dept
                    on e.DeptId equals d.Id
                    select new
                    {
                        e.Id,
                        u.Name,
                        u.Email,
                        u.PhoneNumber,
                        u.DateOfBirth,
                        e.Salary,
                        e.Position,
                        a.Country,
                        a.City,
                        DepartmentName = d.Name
                    }).ToList();

            var result = (from c in userRecord
                          select new GetAllEmployeeRecordResponse()
                          {
                              EmployeeId = c.Id,
                              Name = c.Name,
                              Email = c.Email,
                              PhoneNumber = c.PhoneNumber,
                              DateOfBirth = c.DateOfBirth,
                              Salary = c.Salary,
                              Position = c.Position,
                              Country = c.Country,
                              City = c.City,
                              DepartmentName = c.DepartmentName,
                              Attendances = (from d in atten
                                             where d.EmployeeId == c.Id
                                             select Mappers.AttendanceToAttendanceResponseMapper(d)).ToList()
                          }).ToList();
            return Ok(result);
        }

        [HttpGet("GetAllEmployeeRecord")]
        public ActionResult GetAllEmployeeRecord()
        {
            var emp = _context.Employees.ToList();
            var usr = _context.Users.ToList();
            var addr = _context.Addresses.ToList();
            var dept = _context.Departments.ToList();
            var atten = _context.Attendances.ToList();

            var userRecord =
                   (from e in emp
                    join u in usr
                    on e.UserId equals u.Id into userGroup
                    from us in userGroup.DefaultIfEmpty()
                    join a in addr
                    on us?.AddressId equals a.Id into addrGroup
                    from ad in addrGroup.DefaultIfEmpty()
                    join d in dept
                    on e?.DeptId equals d.Id into deptGroup
                    from de in deptGroup.DefaultIfEmpty()
                    select new
                    {
                        e.Id,
                        us?.Name,
                        us?.Email,
                        us?.PhoneNumber,
                        us?.DateOfBirth,
                        e.Salary,
                        e?.Position,
                        ad?.Country,
                        ad?.City,
                        DepartmentName = de?.Name
                    }).ToList();

            var result = (from c in userRecord
                          select new GetAllEmployeeRecordResponse()
                          {
                              EmployeeId = c.Id,
                              Name = c.Name,
                              Email = c.Email,
                              PhoneNumber = c.PhoneNumber,
                              DateOfBirth = c.DateOfBirth,
                              Salary = c.Salary,
                              Position = c.Position,
                              Country = c.Country,
                              City = c.City,
                              DepartmentName = c.DepartmentName,
                              Attendances = (from d in atten
                                             where d.EmployeeId == c.Id
                                             select Mappers.AttendanceToAttendanceResponseMapper(d)).ToList()
                          }).ToList();
            return Ok(result);
        }

        [HttpGet("GetAllRecord")]
        public ActionResult GetAllRecord()
        {
            var emp = _context.Employees.ToList();
            var usr = _context.Users.ToList();
            var addr = _context.Addresses.ToList();
            var dept = _context.Departments.ToList();
            var atten = _context.Attendances.ToList();

            var userRecord =
                   (from u in usr
                    join e in emp
                    on u.Id equals e.UserId into empGroup
                    from em in empGroup.DefaultIfEmpty()
                    join a in addr
                    on u?.AddressId equals a.Id into addrGroup
                    from ad in addrGroup.DefaultIfEmpty()
                    join d in dept
                    on em?.DeptId equals d.Id into deptGroup
                    from de in deptGroup.DefaultIfEmpty()
                    select new GetAllEmployeeRecordResponse
                    {
                        EmployeeId = em?.Id,
                        Name = u?.Name,
                        Email = u?.Email,
                        PhoneNumber = u?.PhoneNumber,
                        DateOfBirth = u?.DateOfBirth,
                        Salary = em?.Salary,
                        Position = em?.Position,
                        Country = ad?.Country,
                        City = ad?.City,
                        DepartmentName = de?.Name,
                        Attendances = (from d in atten
                                       where d.EmployeeId == em?.Id
                                       select Mappers.AttendanceToAttendanceResponseMapper(d)).ToList()
                    }).ToList();
            return Ok(userRecord);
        }
    }
}

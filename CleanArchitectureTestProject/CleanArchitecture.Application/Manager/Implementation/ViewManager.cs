using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Implementation
{
    public class ViewManager : IViewManager
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public ViewManager(IAddressService addressService, IUserService userService, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _addressService = addressService;
            _userService = userService;
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public async Task<ServiceResult<List<EmployeeResponse>>> GetAllEmployeeDetails()
        {
            var addressList = await _addressService.GetAllAddress();
            var userList = await _userService.GetAllUser();
            var employeeList = await _employeeService.GetAllEmployee();
            var departmentList = await _departmentService.GetAllDepartment();

            var record = (from e in employeeList
                          join u in userList 
                          on e.UserId equals u.Id into userGroup
                          from uG in userGroup.DefaultIfEmpty()
                          join a in addressList
                          on uG?.AddresId equals a.Id into addressGroup
                          from aG in addressGroup.DefaultIfEmpty()
                          join d in departmentList
                          on e.DepartmentId equals d.Id into departmentGroup
                          from dG in departmentGroup.DefaultIfEmpty()
                          select new EmployeeResponse
                          {
                              EmployeeId = e.Id,
                              Name = uG?.Name,
                              Email = uG?.Email,
                              PhoneNumber = uG?.PhoneNumber,
                              DateOfBirth = uG?.DateOfBirth,
                              UniqueId = uG?.UniqueId,
                              Gender = uG?.Gender,
                              Position = e?.Position,
                              Salary = e?.Salary,
                              Country = aG?.Country,
                              City = aG?.City,
                              StreetAddress = aG?.StreetAddress,
                              DepartmentName = dG?.Name,
                          }).ToList();
            if (record.Count < 1)
            {
                return new ServiceResult<List<EmployeeResponse>>
                {
                    Result = ResultStatus.Error,
                    Message = "Employee table is empty",
                    Data = new List<EmployeeResponse>()
                };
            }

            return new ServiceResult<List<EmployeeResponse>>
                {
                Result= ResultStatus.Ok,
                Message = "Displaying all the employee record",
                Data = record
            };
        }
    }
}

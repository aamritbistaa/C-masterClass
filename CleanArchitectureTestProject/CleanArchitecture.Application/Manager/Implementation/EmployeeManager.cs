using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        //private readonly IEmployeeRepository<Employee> _employeeRepository;
        //public EmployeeManager(IEmployeeRepository<Employee> employeeRepository)
        //{
        //    _employeeRepository = employeeRepository;
        //}


        private readonly IEmployeeService _employeeService;
        public EmployeeManager(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<ServiceResult<List<Employee>>> GetAllEmployees()
        {
            var result = await _employeeService.GetAllEmployee();
            if (result == null)
            {
                return new ServiceResult<List<Employee>>
                {
                    Result = ResultStatus.Error,
                    Message = "Employee records is empty",
                    Data = new List<Employee>(),
                };
            }
            return new ServiceResult<List<Employee>>
            {
                Result = ResultStatus.Ok,
                Message = "Employee records",
                Data = result,
            };
        }
        public async Task<ServiceResult<Employee>> GetEmployeeById(int id)
        {
            var item = await _employeeService.GetEmployeeById(id);
            if (item == null)
            {
                return new ServiceResult<Employee>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot find the employee with the specified Id.",
                    Data = new Employee()
                };
            }
            return new ServiceResult<Employee>
            {
                Result = ResultStatus.Ok,
                Message = "Employee with the specified Id.",
                Data = item
            };
        }

        public async Task<ServiceResult<Employee>> AddEmployee(CreateEmployeeRequest request)
        {
            var item = EmployeeMapper.CreateEmployeeRequestToEmployeeMapper(request);

            var result = await _employeeService.AddEmployee(item);
            if (result == null)
            {
                return new ServiceResult<Employee>
                {
                    Result = ResultStatus.Error,
                    Message = "Employee cannot be added",
                    Data = null
                };
            }

            return new ServiceResult<Employee>
            {
                Result = ResultStatus.Error,
                Message = "Employee has been added",
                Data = result
            };

        }
        public async Task<ServiceResult<Employee>> UpdateEmployee(UpdateEmployeeRequest request)
        {
            var item = await _employeeService.GetEmployeeById(request.Id);

            if (item == null)
            {
                return new ServiceResult<Employee>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot find the employee with the specified Id.",
                    Data = null
                };
            }
            item.Position = request.Position;
            item.Salary = request.Salary;
            if(request.DepartmentId != null)
            {
                item.DepartmentId = request.DepartmentId;
            }

            var result = await _employeeService.UpdateEmployee(item);
            if (result == false)
            {
                return new ServiceResult<Employee>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot update the employee.",
                    Data = item
                };
            }
            return new ServiceResult<Employee>
            {
                Result = ResultStatus.Ok,
                Message = "Employee updated successfully.",
                Data = item
            };
        }

        public async Task<ServiceResult<bool>> DeleteEmployee(int id)
        {
            var item = await _employeeService.GetEmployeeById(id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot find employee",
                    Data = false
                };
            }
            item.IsDeleted = true;
            var result = await _employeeService.UpdateEmployee(item);
            if (!result)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot delete employee",
                    Data = false
                };
            }
            return new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "Employee has been deleted",
                Data = false
            };
        }
    }
}

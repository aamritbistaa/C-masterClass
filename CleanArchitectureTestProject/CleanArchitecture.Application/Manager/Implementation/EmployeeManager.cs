using AutoMapper;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
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
        private readonly IMapper _mapper;
        private readonly IEmployeeServiceFactory _factory;
        public EmployeeManager(IEmployeeService employeeService, IMapper mapper, IEmployeeServiceFactory factory)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _factory = factory;
        }
        public async Task<ServiceResult<List<EmployeeResponse>>> GetAllEmployees()
        {
            var response = await _employeeService.GetAllEmployee();
            var result =
                (
                from item in response
                select _mapper.Map<EmployeeResponse>(item)
                 ).ToList();

            if (result == null)
            {
                return new ServiceResult<List<EmployeeResponse>>
                {
                    Result = ResultStatus.Error,
                    Message = "Employee records is empty",
                    Data = new List<EmployeeResponse>(),
                };
            }
            return new ServiceResult<List<EmployeeResponse>>
            {
                Result = ResultStatus.Ok,
                Message = "Employee records",
                Data = result,
            };
        }
        public async Task<ServiceResult<EmployeeResponse>> GetEmployeeById(int id)
        {
            var item = await _employeeService.GetEmployeeById(id);
            var result = _mapper.Map<EmployeeResponse>(item);
            if (result == null)
            {
                return new ServiceResult<EmployeeResponse>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot find the employee with the specified Id.",
                    Data = new EmployeeResponse()
                };
            }
            return new ServiceResult<EmployeeResponse>
            {
                Result = ResultStatus.Ok,
                Message = "Employee with the specified Id.",
                Data = result
            };
        }

        public async Task<ServiceResult<EmployeeResponse>> AddEmployee(CreateEmployeeRequest request)
        {
            //var item = EmployeeMapper.CreateEmployeeRequestToEmployeeMapper(request);
            var item = _mapper.Map<Employee>(request);
            try
            {
                _factory.BeginTransaction();
                var response = await _employeeService.AddEmployee(item);
                var result = _mapper.Map<EmployeeResponse>(response);
                if (result == null)
                {
                    _factory.RollBack();
                    return new ServiceResult<EmployeeResponse>
                    {
                        Result = ResultStatus.Error,
                        Message = "Employee cannot be added",
                        Data = null
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<EmployeeResponse>
                {
                    Result = ResultStatus.Error,
                    Message = "Employee has been added",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }


        }
        public async Task<ServiceResult<bool>> UpdateEmployee(UpdateEmployeeRequest request)
        {
            var item = await _employeeService.GetEmployeeById(request.Id);

            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Cannot find the employee with the specified Id.",
                    Data = false
                };
            }
            try
            {
                _factory.BeginTransaction();
                item.Position = request.Position;
                item.Salary = request.Salary;
                if (request.DepartmentId != null)
                {
                    item.DepartmentId = request.DepartmentId;
                }
                var result = await _employeeService.UpdateEmployee(item);
                if (result == false)
                {
                    _factory.RollBack();
                    return new ServiceResult<bool>
                    {
                        Result = ResultStatus.Error,
                        Message = "Cannot update the employee.",
                        Data = result
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = "Employee updated successfully.",
                    Data = result
                };
            }
            catch(Exception ex) 
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
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
            try
            {
                _factory.BeginTransaction();
                item.IsDeleted = true;
                var result = await _employeeService.UpdateEmployee(item);
                if (!result)
                {
                    _factory.RollBack();
                    return new ServiceResult<bool>
                    {
                        Result = ResultStatus.Error,
                        Message = "Cannot delete employee",
                        Data = false
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = "Employee has been deleted",
                    Data = false
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
        }
    }
}

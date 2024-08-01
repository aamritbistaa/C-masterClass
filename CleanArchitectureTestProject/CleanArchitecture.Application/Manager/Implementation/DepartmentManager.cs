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
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        private readonly IEmployeeServiceFactory _factory;
        public DepartmentManager(IDepartmentService departmentService, IMapper mapper, IEmployeeServiceFactory factory)
        {
            _factory = factory;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<DepartmentResponse>>> GetAllDepartment()
        {
            var response = await _departmentService.GetAllDepartment();
            var result = (from item in response
                          select _mapper.Map<DepartmentResponse>(item))
                          .ToList();

            //var result = _mapper.Map<List<DepartmentResponse>>(response);
            if (result.Count == 0)
            {
                return new ServiceResult<List<DepartmentResponse>>
                {
                    Result = ResultStatus.Error,
                    Message = "Department table is empty.",
                    Data = new List<DepartmentResponse>()
                };
            }
            return new ServiceResult<List<DepartmentResponse>>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying department records.",
                Data = result
            };
        }

        public async Task<ServiceResult<DepartmentResponse>> GetDepartmentById(int id)
        {
            var response = await _departmentService.GetDepartmentById(id);
            var result = _mapper.Map<DepartmentResponse>(response);
            if (result == null)
            {
                return new ServiceResult<DepartmentResponse>
                {
                    Result = ResultStatus.Error,
                    Message = "Department with specified id does not exist.",
                    Data = new DepartmentResponse()
                };
            }
            return new ServiceResult<DepartmentResponse>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying department record.",
                Data = result
            };

        }
        public async Task<ServiceResult<DepartmentResponse>> AddDepartment(CreateDepartmentRequest request)
        {
            try
            {
                _factory.BeginTransaction();
                var item = _mapper.Map<Department>(request);
                var response = await _departmentService.AddDepartment(item);
                var result = _mapper.Map<DepartmentResponse>(response);
                if (result == null)
                {
                    _factory.RollBack();
                    return new ServiceResult<DepartmentResponse>
                    {
                        Result = ResultStatus.Error,
                        Message = "Error adding department",
                        Data = null
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<DepartmentResponse>
                {
                    Result = ResultStatus.Ok,
                    Message = "Deprtment added successfully",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
            //mapp the reqeust
            //var item = DepartmentMapper.CreateDepartmentRequestToDepartmentMapper(request);

        }
        public async Task<ServiceResult<bool>> UpdateDepartment(UpdateDepartmentRequest request)
        {
            var item = await _departmentService.GetDepartmentById(request.Id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Unable to find department with specified Id.",
                    Data = false
                };
            }
            try
            {
                _factory.BeginTransaction();
                item.Name = request.Name;
                var result = await _departmentService.UpdateDepartment(item);
                if (result == false)
                {
                    _factory.RollBack();
                    return new ServiceResult<bool>
                    {
                        Result = ResultStatus.Error,
                        Message = "Error occured while updaing the department.",
                        Data = result
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = "Department updated successfully.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> DeleteDepartment(int id)
        {
            var item = await _departmentService.GetDepartmentById(id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Unable to find the department with specified Id."
                };
            }
            try
            {
                _factory.BeginTransaction();
                item.IsDeleted = true;
                var result = await _departmentService.UpdateDepartment(item);
                if (result == false)
                {
                    _factory.RollBack();
                    return new ServiceResult<bool>
                    {
                        Result = ResultStatus.Error,
                        Message = "Error occured while deleting the department.",
                        Data = result
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = "Department deleted successfully.",
                    Data = result
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

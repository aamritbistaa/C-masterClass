using AutoMapper;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using static CleanArchitecture.Application.Common.CommonUtils;
using static CleanArchitecture.Application.Common.Message;

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
            if (response.Count == 0)
            {
                return new ServiceResult<List<DepartmentResponse>>
                {
                    Result = ResultStatus.Error,
                    Message = DepartmentMessage.Empty,
                    Data = new List<DepartmentResponse>()
                };
            }
            var result = (from item in response
                          select _mapper.Map<DepartmentResponse>(item))
                          .ToList();

            //var result = _mapper.Map<List<DepartmentResponse>>(response);
            
            return new ServiceResult<List<DepartmentResponse>>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.Displaying,
                Data = result
            };
        }

        public async Task<ServiceResult<DepartmentResponse>> GetDepartmentById(int id)
        {
            var response = await _departmentService.GetDepartmentById(id);
            if (response == null)
            {
                return new ServiceResult<DepartmentResponse>
                {
                    Result = ResultStatus.Error,
                    Message = DepartmentMessage.ItemNotFound,
                    Data = new DepartmentResponse()
                };
            }
            var result = _mapper.Map<DepartmentResponse>(response);
            return new ServiceResult<DepartmentResponse>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.Displaying,
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
                if (response == null)
                {
                    _factory.RollBack();
                    return new ServiceResult<DepartmentResponse>
                    {
                        Result = ResultStatus.Error,
                        Message = DepartmentMessage.ErrorWhileAdding,
                        Data = null
                    };
                }
                var result = _mapper.Map<DepartmentResponse>(response);
                _factory.CommitTransaction();
                return new ServiceResult<DepartmentResponse>
                {
                    Result = ResultStatus.Ok,
                    Message = DepartmentMessage.SuccessAdding,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> UpdateDepartment(UpdateDepartmentRequest request)
        {
            var item = await _departmentService.GetDepartmentById(request.Id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = DepartmentMessage.ItemNotFound,
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
                        Message = DepartmentMessage.ErrorWhileUpdating,
                        Data = result
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = DepartmentMessage.SuccessUpdating,
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
                    Message = DepartmentMessage.ItemNotFound
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
                        Message = DepartmentMessage.ErrorWhileDeleting,
                        Data = result
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = DepartmentMessage.SuccessDeleting,
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

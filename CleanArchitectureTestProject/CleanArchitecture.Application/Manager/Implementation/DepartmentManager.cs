using CleanArchitecture.Application.DTO.Request;
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

        public DepartmentManager(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<ServiceResult<List<Department>>> GetAllDepartment()
        {
            var result = await _departmentService.GetAllDepartment();
            if (result.Count == 0) {
                return new ServiceResult<List<Department>>
                {
                    Result = ResultStatus.Error,
                    Message = "Department table is empty.",
                    Data = new List<Department>()
                };
            }
            return new ServiceResult<List<Department>>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying department records.",
                Data = result
            };
        }

        public async Task<ServiceResult<Department>> GetDepartmentById(int id)
        {
            var result = await _departmentService.GetDepartmentById(id);
            if (result == null)
            {
                return new ServiceResult<Department>
                {
                    Result = ResultStatus.Error,
                    Message = "Department with specified id does not exist.",
                    Data = new Department()
                };
            }
            return new ServiceResult<Department>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying department record.",
                Data = result
            };
        }
        public async Task<ServiceResult<Department>> AddDepartment(CreateDepartmentRequest request)
        {
            //mapp the reqeust
            var item = DepartmentMapper.CreateDepartmentRequestToDepartmentMapper(request);
            var result =  await _departmentService.AddDepartment(item);
            if (result == null)
            {
                return new ServiceResult<Department>
                {
                    Result = ResultStatus.Error,
                    Message = "Error adding department",
                    Data = null
                };

            }
            return new ServiceResult<Department>
            {
                Result = ResultStatus.Ok,
                Message = "Deprtment added successfully",
                Data = result
            };
        }
        public async Task<ServiceResult<bool>> UpdateDepartment(UpdateDepartmentRequest request)
        {
            var item = await _departmentService.GetDepartmentById(request.Id);
            if(item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Unable to find department with specified Id.",
                    Data = false
                };
            }

            item.Name = request.Name;
            var result = await _departmentService.UpdateDepartment(item);
            if (result == false)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Error occured while updaing the department.",
                    Data = result
                };
            }
            return new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "Department updated successfully.",
                Data = result
            };
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
            item.IsDeleted = true;

            var result = await _departmentService.UpdateDepartment(item);

            if(result == false)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Error occured while deleting the department.",
                    Data = result
                };
            }
            return new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "Department deleted successfully.",
                Data = result
            };
        }
    }
}

using AutoMapper;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using System.Runtime.InteropServices;
using static CleanArchitecture.Application.Common.CommonUtils;
using static CleanArchitecture.Application.Common.Message.UserMessage;

namespace CleanArchitecture.Application.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IEmployeeServiceFactory _factory;
        public UserManager(IUserService userService, IMapper mapper, IEmployeeServiceFactory factory)
        {
            _userService = userService;
            _mapper = mapper;
            _factory = factory;
        }

        public async Task<ServiceResult<List<UserResponse>>> GetAllUser()
        {
            var response = await _userService.GetAllUser();
            var result = (from item in response
                          select _mapper.Map<UserResponse>(item)).ToList();
            if (result.Count == 0)
            {
                return new ServiceResult<List<UserResponse>>
                {
                    Result = ResultStatus.Error,
                    Message = Empty,
                    Data = new List<UserResponse>()
                };
            }
            return new ServiceResult<List<UserResponse>>
            {
                Result = ResultStatus.Ok,
                Message = Displaying,
                Data = result
            };
        }
        public async Task<ServiceResult<UserResponse>> GetUserById(int id)
        {
            var response = await _userService.GetUserById(id);
            var result = _mapper.Map<UserResponse>(response);
            if (result == null)
            {
                return new ServiceResult<UserResponse>
                {
                    Result = ResultStatus.Error,
                    Message = ItemNotFound,
                    Data = new UserResponse()
                };
            }
            return new ServiceResult<UserResponse>
            {
                Result = ResultStatus.Ok,
                Message = Displaying,
                Data = result
            };
        }
        public async Task<ServiceResult<UserResponse>> AddUser(CreateUserRequest request)
        {
            var item = _mapper.Map<User>(request);
            var pastRecord = (await _userService.GetAllUser()).Where(x => x.PhoneNumber == request.PhoneNumber || x.Email == request.Email || x.UniqueId == request.UniqueId);

            if (pastRecord.Any())
            {
                return new ServiceResult<UserResponse>
                {
                    Result = ResultStatus.Error,
                    Message = "A user with the specified email, phone, or unique ID already exists.",
                    Data = new UserResponse()
                };
            }
            try
            {
                _factory.BeginTransaction();
                var response = await _userService.AddUser(item);
                var result = _mapper.Map<UserResponse>(response);
                if (result == null)
                {
                    _factory.RollBack();
                    return new ServiceResult<UserResponse>
                    {
                        Result = ResultStatus.Error,
                        Message = ErrorWhileAdding,
                        Data = new UserResponse()
                    };
                }
                _factory.CommitTransaction();
                return new ServiceResult<UserResponse>
                {
                    Result = ResultStatus.Ok,
                    Message = SuccessAdding,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> UpdateUser(UpdateUserRequest request)
        {
            var item = await _userService.GetUserById(request.Id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = ItemNotFound,
                    Data = false
                };
            }
            var recordsFromDb = (await _userService.GetAllUser()).Where(x => x.Id != request.Id);
            var repeatedItems = (from records in recordsFromDb
                                 where request.UniqueId == records.UniqueId || request.Email == records.Email || request.PhoneNumber == records.PhoneNumber
                                 select records
                                ).ToList();
            if (repeatedItems.Any())
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "A user with the specified email, phone, or unique ID already exists.",
                    Data = false
                };
            }
            try
            {
                _factory.BeginTransaction();
                item.Name = request.Name;
                item.DateOfBirth = request.DateOfBirth;
                item.PhoneNumber = request.PhoneNumber;
                item.Email = request.Email;
                item.UniqueId = request.UniqueId;
                item.Gender = request.Gender;
                item.AddresId = request.AddresId;
                var result = await _userService.UpdateUser(item);
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = SuccessUpdating,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _factory.RollBack();
                throw new Exception(ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> DeleteUser(int id)
        {
            var item = await _userService.GetUserById(id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = ItemNotFound,
                    Data = false
                };
            }
            try
            {
                _factory.BeginTransaction();
                item.IsDeleted = true;
                var result = await _userService.UpdateUser(item);
                _factory.CommitTransaction();
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Ok,
                    Message = SuccessDeleting,
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

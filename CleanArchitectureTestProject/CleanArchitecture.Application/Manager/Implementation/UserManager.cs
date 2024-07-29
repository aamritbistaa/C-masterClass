using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ServiceResult<List<User>>> GetAllUser()
        {
            var result = await _userService.GetAllUser();
            if (result.Count == 0)
            {
                return new ServiceResult<List<User>>
                {
                    Result = ResultStatus.Error,
                    Message = "User table is empty",
                    Data = new List<User>()
                };
            }
            return new ServiceResult<List<User>>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying user table",
                Data = result
            };
        }
        public async Task<ServiceResult<User>> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            if (result == null)
            {
                return new ServiceResult<User>
                {
                    Result = ResultStatus.Error,
                    Message = "User table is empty",
                    Data = new User()
                };
            }
            return new ServiceResult<User>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying user table",
                Data = result
            };
        }
        public async Task<ServiceResult<User>> AddUser(CreateUserRequest request)
        {

            var item = UserMapper.CreateUserRequestToUser(request);

            //To check if email or phone or unique id is already present in the db
            var pastRecord = (await _userService.GetAllUser()).Where(x => x.PhoneNumber == request.PhoneNumber || x.Email == request.Email || x.UniqueId == request.UniqueId);

            if (pastRecord.Any())
            {
                return new ServiceResult<User>
                {
                    Result = ResultStatus.Error,
                    Message = "User with specified email, phone or unique id is already present",
                    Data = item
                };
            }

            var result = await _userService.AddUser(item);

            if (result == null)
            {
                return new ServiceResult<User>
                {
                    Result = ResultStatus.Error,
                    Message = "Unable to add user User",
                    Data = item
                };
            }
            return new ServiceResult<User>
            {
                Result = ResultStatus.Ok,
                Message = "User has been added.",
                Data = result
            };

        }
        public async Task<ServiceResult<bool>> UpdateUser(UpdateUserRequest request)
        {
            var item = await _userService.GetUserById(request.Id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Unable to find User with the specified Id",
                    Data = false
                };
            }
            //Check if requested email, phonenumber or unique id is already there in the db
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
                    Message = "User with specified email, phone or unique id is already present",
                    Data = false
                };
            }

            item.Name = request.Name;
            item.DateOfBirth = request.DateOfBirth;
            item.PhoneNumber = request.PhoneNumber;
            item.Email = request.Email;
            item.UniqueId = request.UniqueId;
            item.Gender = request.Gender;
            item.AddresId = request.AddresId;
            var result = await _userService.UpdateUser(item);

            return new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "User has be updated",
                Data = result
            };
        }
        public async Task<ServiceResult<bool>> DeleteUser(int id)
        {
            var item = await _userService.GetUserById(id);
            if (item == null)
            {
                return new ServiceResult<bool>
                {
                    Result = ResultStatus.Error,
                    Message = "Unable to find User with the specified Id",
                    Data = false
                };
            }
            item.IsDeleted = true;
            var result = await _userService.UpdateUser(item);
            return new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "User has be deleted",
                Data = result
            };
        }
    }
}

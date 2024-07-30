using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Application.Manager.Interface
{
    public interface IUserManager
    {
        Task<ServiceResult<List<UserResponse>>> GetAllUser();
        Task<ServiceResult<UserResponse>> GetUserById(int id);
        Task<ServiceResult<UserResponse>> AddUser(CreateUserRequest request);
        Task<ServiceResult<bool>> UpdateUser(UpdateUserRequest request);
        Task<ServiceResult<bool>> DeleteUser(int id);
    }
}

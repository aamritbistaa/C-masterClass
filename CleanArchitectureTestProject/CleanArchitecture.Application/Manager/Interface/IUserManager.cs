using CleanArchitecture.Application.DTO.Request;
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
        Task<ServiceResult<List<User>>> GetAllUser();
        Task<ServiceResult<User>> GetUserById(int id);
        Task<ServiceResult<User>> AddUser(CreateUserRequest request);
        Task<ServiceResult<bool>> UpdateUser(UpdateUserRequest request);
        Task<ServiceResult<bool>> DeleteUser(int id);
    }
}

using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Service.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User request);
        Task<bool> UpdateUser(User request);
    }
}
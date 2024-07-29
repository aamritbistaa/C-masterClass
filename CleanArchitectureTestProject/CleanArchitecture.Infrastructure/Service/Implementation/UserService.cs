using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IEmployeeRepository<User> _userService;

        public UserService(IEmployeeRepository<User> userService)
        {
            _userService = userService;
        }
        public async Task<List<User>> GetAllUser()
        {
            var result = await _userService.ListAsync();
            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _userService.FindAsync(id);
            return result;
        }
        public async Task<User> AddUser(User request)
        {
            var result = await _userService.AddAsync(request);
            return result;
        }
        public async Task<bool> UpdateUser(User request)
        {
            var result = await _userService.UpdateAsync(request);
            return result;
        }
    }
}

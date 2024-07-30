using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
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
        //private readonly IEmployeeRepository<User> _userService;

        //public UserService(IEmployeeRepository<User> userService)
        //{
        //    _userService = userService;
        //}
        private readonly IEmployeeServiceFactory _factory;

        public UserService(IEmployeeServiceFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<User>> GetAllUser()
        {
            var result = await _factory.GetInstance<User>().ListAsync();
            //var result = await _userService.ListAsync();
            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _factory.GetInstance<User>().FindAsync(id);
            //var result = await _userService.FindAsync(id);
            return result;
        }
        public async Task<User> AddUser(User request)
        {
            var result = _factory.GetInstance<User>();
            var response = await result.AddAsync(request);
            //var result = await _userService.AddAsync(request);
            return response;
        }
        public async Task<bool> UpdateUser(User request)
        {
            var result = await _factory.GetInstance<User>().UpdateAsync(request);
            //var result = await _userService.UpdateAsync(request);
            return result;
        }
    }
}

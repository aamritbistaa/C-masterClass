using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using static CleanArchitecture.Application.Common.CommonUtils;


namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("GetAllUser")]
        public async Task<ServiceResult<List<User>>> GetAllUser()
        {
            var result = await _userManager.GetAllUser();
            return result;
        }
        [HttpGet("GetUserById")]
        public async Task<ServiceResult<User>> GetUserById(int id)
        {
            var result = await _userManager.GetUserById(id);
            return result;
        }
        [HttpPost("AddUser")]
        public async Task<ServiceResult<User>> AddUser(CreateUserRequest request)
        {
            var result = await _userManager.AddUser(request);
            return result;
        }
        [HttpPut("UpdateUser")]
        public async Task<ServiceResult<bool>> UpdateUser(UpdateUserRequest request)
        {
            var result = await _userManager.UpdateUser(request);
            return result;
        }
        [HttpDelete("DeleteUser")]
        public async Task<ServiceResult<bool>> DeleteUser(int id)
        {
            var result = await _userManager.DeleteUser(id);
            return result;
        }
    }
}

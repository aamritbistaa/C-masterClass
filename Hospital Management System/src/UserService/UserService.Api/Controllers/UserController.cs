using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using UserService.Application.Feature.User.Command;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserServie.Application.Feature.User.Command;
using UserServie.Application.Feature.User.Query;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ISender _sender;
        private readonly Serilog.ILogger _logger;

        public UserController(ISender sender, Serilog.ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }
        /// <summary>
        /// This api is used to give basic information and register the user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/register")]
        public async Task<ServiceResult<string>> Registration(CreateUserCommand request)
        {
            _logger.Verbose("Register initiated");
            var result = await _sender.Send(request);
            return result;
        }
        /// <summary>
        /// THis api is used to validate the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/Validate")]
        public async Task<ServiceResult<string>> Validate(ValidateUserCommand request)
        {
            _logger.Verbose("Validate initiated");
            var result = await _sender.Send(request);
            return result;
        }
        /// <summary>
        /// This api is used to get all the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ServiceResult<List<GetAllUserResponse>>> GetAllUser([FromQuery] GetAllUserQuery request)
        {
            _logger.Verbose("Get all user initiated");
            var result = await _sender.Send(request);
            return result;
        }


        [HttpPost("/AdditionalUserDetail")]
        public async Task<ServiceResult<string>> AddUserDetail(AddAdditionalUserCommand request)
        {
            _logger.Verbose("Add additional user ccommand initiated");
            var result = await _sender.Send(request);
            return result;
        }
        //Get User by Id

    }
}

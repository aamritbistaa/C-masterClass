using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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

        [HttpPost("/register")]
        public async Task<ServiceResult<string>> Registration(CreateUserCommand request)
        {
            _logger.Verbose("Register initiated");
            var result = await _sender.Send(request);
            return result;
        }
        [HttpPost("/Validate")]
        public async Task<ServiceResult<string>> Validate(ValidateUserCommand request)
        {
            _logger.Verbose("Validate initiated");
            var result = await _sender.Send(request);
            return result;
        }
        [HttpGet("")]
        public async Task<ServiceResult<List<GetAllUserResponse>>> GetAllUser([FromQuery] GetAllUserQuery request)
        {
            _logger.Verbose("Get all user initiated");
            var result = await _sender.Send(request);
            return result;
        }

    }
}

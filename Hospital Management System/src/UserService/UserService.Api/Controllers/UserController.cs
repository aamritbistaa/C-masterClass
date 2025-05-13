using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using UserService.Domain.Abstraction;
using UserServie.Application.Feature.User.Command;

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
        [HttpPost]
        public async Task<ServiceResult<string>> Validate(ValidateUserCommand request)
        {
            _logger.Verbose("Validate initiated");
            var result = await _sender.Send(request);
            return result;
        }
        
    }
}

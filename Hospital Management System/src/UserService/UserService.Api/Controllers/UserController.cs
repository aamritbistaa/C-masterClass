using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        public async Task<IActionResult> Registration(CreateUserCommand requsest)
        {
            _logger.Verbose("Register initiated");
            var result = await _sender.Send(requsest);
            return Ok(result);
        }
    }
}

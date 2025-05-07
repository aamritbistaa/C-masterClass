using MediatR;
using Microsoft.AspNetCore.Http;
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

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Registration(CreateUserCommand requsest)
        {
            Log.Error("Register");
            var result = await _sender.Send(requsest);
            return Ok(result);
        }
    }
}

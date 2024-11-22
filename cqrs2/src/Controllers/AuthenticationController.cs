using Azure;
using CQRSApplication.Command.AuthUserCommand;
using CQRSApplication.Context;
using CQRSApplication.Helpers;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CQRSApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly CQRSDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly EmailService _emailService;

        public AuthenticationController(CQRSDbContext dbContext, IConfiguration configuration, IMediator mediator, ILogger<AuthenticationController> logger, EmailService emailService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mediator = mediator;
            _logger = logger;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] CreateUserCommand command, CancellationToken cancellationToken, IBackgroundJobClient backgroundJobs)
        {

            try
            {
                var response = await _mediator.Send(command, cancellationToken);
                Log.Information("User {@response.Id} created Successfully");
                //Fire and Forget Task
                backgroundJobs.Enqueue(() => _emailService.UserRegisteredEmail(command.UserCredentials.Email));
                return Ok(response);
            }
            catch (Exception ex)
            {
                command.UserCredentials.Password = null;
                Log.Error("Unable to create user with information {@request} \n {@message}", command, ex.Message);
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command, CancellationToken cancellationToken, IBackgroundJobClient backgroundJobs)
        {
            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                //Delayed Task
                backgroundJobs.Schedule(() => _emailService.UserLoggedInEmail(command.Email), TimeSpan.FromMinutes(1));
                Log.Information("User logged in Successfully with Id: {@UserId}", response.UserId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error("Login failed for user with email: {@Email} \n {@message}", command.Email, ex.Message);

                if (ex.Message == "Invalid credentials")
                {
                    backgroundJobs.Enqueue(() => _emailService.UnAuthenticatedUserTriedToLoggIn(command.Email));
                }

                return StatusCode(500, $"Internal server Error:{ex.Message}");
            }
        }
    }
}

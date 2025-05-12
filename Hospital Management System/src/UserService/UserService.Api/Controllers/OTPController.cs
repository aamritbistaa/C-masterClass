using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserServie.Application.Feature.OTP;
using ILogger = Serilog.ILogger;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger _logger;
        public OTPController(ISender sender, ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost("/Generate")]
        public async Task<ServiceResult<string>> GenerateOtp(GenerateOtpCommand request)
        {
            _logger.Verbose("Generate Otp initiated");
            var result = await _sender.Send(request);
            return result;
        }

        // Support reset otp
        // [HttpPost("/Reset")]
        // public async Task<IActionResult> ResetOtp(Guid userId, OTPType oTPType)
        // {

        // }
    }
}

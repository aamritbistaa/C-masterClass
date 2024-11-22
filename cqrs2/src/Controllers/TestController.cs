using CQRSApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CQRSApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly EmailService _emailService;

        public TestController(EmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public async Task<IActionResult> GetHeder()
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == "UserId").Value;
            
            return Ok(id);
        }
        [HttpPost]
        public async Task<IActionResult> UserRegistration()
        {

            await _emailService.UserRegisteredEmail("aamritbistaa@gmail.com");
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> InvalidLogin()
        {
            await _emailService.UnAuthenticatedUserTriedToLoggIn("aamritbistaa@gmail.com");
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> SucessfulLogin()
        {
            await _emailService.UserLoggedInEmail("aamritbistaa@gmail.com");
            return Ok();
        }
    }
}

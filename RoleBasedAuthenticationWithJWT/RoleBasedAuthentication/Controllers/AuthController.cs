using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthentication.Model;
using RoleBasedAuthentication.Services;
using System.IdentityModel.Tokens.Jwt;

namespace RoleBasedAuthentication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        //POST: auth/login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            //Error Check
            if (String.IsNullOrEmpty(user.UserName))
            {
                return BadRequest(new { message = "User name is empty" });
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { message = "Password is empty" });
            }

            //Try login
            var loggedInUser = await _authService.Login(new User(user.UserName, "", user.Password, null));


            //return reseponse
            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }
            return BadRequest(new { message = "User login unsuccessful" });
        }


        //Post: auth/register
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
        //ErrorCheck
            if(String.IsNullOrEmpty(registerUser.Name))
            {
                return BadRequest(new{message = "Name is empty"});
            }
            else if (String.IsNullOrEmpty(registerUser.UserName))
            {
                return BadRequest(new { message = "User name is empty" });
            }
            else if (String.IsNullOrEmpty(registerUser.Password))
            {
                return BadRequest(new { message = "Password is empty" });
            }

            //try registration
            var registeredUser = await _authService.Register(new User(registerUser.UserName, registerUser.Name, registerUser.Password, registerUser.Roles));

            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }
            return BadRequest(new { message = "Unable to register user" });

        }
        //Get: auth/test
        [Authorize(Roles ="User")]
        [HttpGet]
        public IActionResult Test()
        {
            //Get token from header
            string token = Request.Headers["Authorization"];
            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            var handler = new JwtSecurityTokenHandler();
            //Return all claims present in the token
            JwtSecurityToken jwt = handler.ReadJwtToken(token);
            var claims = "List of Claims: \n";
            foreach (var claim in jwt.Claims)
            {
                claims += $"{claim.Type}: {claim.Value}\n";
            }
            return Ok(claims);
        }



    }
}


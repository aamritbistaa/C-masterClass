using CRUD_with_auth.Configurations;
using CRUD_with_auth.Models;
using CRUD_with_auth.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD_with_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        public AuthenticationController(UserManager<IdentityUser> userManager, JwtConfig jwtConfig)
        {
            _userManager=userManager;
            _jwtConfig=jwtConfig;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            //Validate Incomming request
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //we need to check if email already exist
            var user_exist = await _userManager.FindByEmailAsync(requestDto.Email);
            if (user_exist!=null)
            {
                return BadRequest(error: new AuthResult()
                {
                    Result=false,
                    Errors = new List<string>() { 
                    "Email already exist"
                    }
                });
            }

            //Create user
            var new_user = new IdentityUser()
            {
                Email=requestDto.Email,
                UserName= requestDto.Email,

            };
            var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);
            if (!is_created.Succeeded)
            {
                return BadRequest(new AuthResult()
                {
                    Result=false,
                    Errors = new List<String>()
                    {
                        "Server Error, Unable to create user"
                    }
                });
            }
            var token  = GenerateJwtToken(new_user);
            return Ok(new AuthResult()
            {
                Result = true,
                Token = token
            });
            // user has been created successfully, so create the token

        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            //Token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(type: "id", value: user.Id),
                        new Claim(type: Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, value: user.Email),
                        new Claim(type:Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email,value:user.Email),
                        new Claim(type:Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti,value:Guid.NewGuid().ToString()),
                        new Claim(type:Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Iat,value:DateTime.Now.ToUniversalTime().ToString()),


                    }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        
        
        }
    }
}

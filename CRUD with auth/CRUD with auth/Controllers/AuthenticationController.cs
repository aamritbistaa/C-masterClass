using CRUD_with_auth.Configurations;
using CRUD_with_auth.Models;
using CRUD_with_auth.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace CRUD_with_auth.Controllers
{
    //String1@gmail.com
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly JwtConfig _jwtConfig;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<IdentityUser> userManager, 
            //JwtConfig jwtConfig,
            IConfiguration configuration)
        {
            _userManager = userManager;
            //_jwtConfig = jwtConfig;
            _configuration = configuration;
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
            if (user_exist != null)
            {
                return BadRequest(error: new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>() {
                    "Email already exist"
                    }
                });
            }

            //Create user
            var new_user = new IdentityUser()
            {
                Email = requestDto.Email,
                UserName = requestDto.Email,
            };
            var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);
            if (!is_created.Succeeded)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<String>()
                    {
                        "Server Error, Unable to create user"
                    }
                });
            }
            // user has been created successfully, so create the token
            var token = GenerateJwtToken(new_user);
            return Ok(new AuthResult()
            {
                Result = true,
                Token = token
            });

        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto request)
        {
            if (ModelState.IsValid)
            {
                //check if the user exist
                var existing_user = await _userManager.FindByEmailAsync(request.Email);
                if (existing_user == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>() { "Invalid payload" },
                        Result= false,
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existing_user,request.Password);

                if (!isCorrect)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid Credentials"
                        },
                        Result=false,
                    });
                }
                var jwtToken = GenerateJwtToken(existing_user);
                return Ok(new AuthResult()
                {
                    Token = jwtToken,
                    Result = true,
                });
            }
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid Payload"
                },
                Result=false
            });
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

            //Token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                    {       
                        new Claim(type: "id", value: user.Id),
                        new Claim(type: Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, value: user.Email),
                        new Claim(type:Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email,value:user.Email),
                        new Claim(type:Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti,value:Guid.NewGuid().ToString()),
                        new Claim(type:Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Iat,value:DateTime.Now.ToUniversalTime().ToString()),
                    }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}

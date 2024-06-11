using Isopoh.Cryptography.Argon2;
using Microsoft.IdentityModel.Tokens;
using RoleBasedAuthentication.Data;
using RoleBasedAuthentication.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoleBasedAuthentication.Services
{
    public interface IAuthService
    {
        public Task<User> Login(User loginUser);
        public Task<User> Register(User registerUser);
    }
    public class AuthService : IAuthService
    { 
        //private readonly IAuthService _authService;
        private readonly UserDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthService(
            UserDbContext dbContext,
            IConfiguration configuration
            )
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<User> Login(User loginUser)
        {
            //Search User in DB and verify Passowrd
            var user = await _dbContext.Users.FindAsync(loginUser.UserName);
            if (user == null || Argon2.Verify(user.Password, loginUser.Password) == false)
            {
                return null;
            }

            //Create JWT token handler and get secret key
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

            //prepre list of user claims

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.GivenName,user.Name)
            };
            foreach(var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //Create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            //create Token and set it to user
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.IsActive = true;
            return user;

        }


        public async Task<User> Register(User registerUser)
        {
            //Add user to DB

            registerUser.Password = Argon2.Hash(registerUser.Password);
            _dbContext.Users.Add(registerUser);
            await _dbContext.SaveChangesAsync();
            return registerUser;
        }
    }
}

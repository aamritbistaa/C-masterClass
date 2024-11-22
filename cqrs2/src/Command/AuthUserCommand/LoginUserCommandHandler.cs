using CQRSApplication.Context;
using Hangfire;
using Isopoh.Cryptography.Argon2;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CQRSApplication.Command.AuthUserCommand
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly CQRSDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public LoginUserCommandHandler(CQRSDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            var userCredential = await _dbContext.UserCredentials
                            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            //var requestPassword = Argon2.Hash(request.Password);
            if (userCredential == null)
            {
                throw new Exception("User with specified email doesnot exist");
            }

            if (!Argon2.Verify(userCredential.Password,request.Password))
            {
                Log.Warning("Invalid Credentials: {@credentials}", request);
                throw new Exception(message: "Invalid credentials");
            }
            var userDetails = await _dbContext.Users
                                .FirstOrDefaultAsync(u => u.UserCredentialsId == userCredential.Id, cancellationToken);

            if (userDetails == null)
            {
                Log.Error("Unable to find user with user credential id: {@CredentialId}}", userCredential.Id);
                throw new Exception(message: "User does not exists");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);
            //preparing list of user claims
            //role, userId
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userCredential.UserName),
                new Claim("UserId", userDetails.Id.ToString()),
                new Claim(ClaimTypes.Role,userCredential.Role.ToString()),
            };
            //Create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            userCredential.Token = tokenHandler.WriteToken(token);
            userCredential.IsActive = true;
            await _dbContext.SaveChangesAsync();

            Log.Information("Token Generated for {@UserId} with {@token} ", userDetails.Id, userCredential.Token);


            return new LoginUserResponse
            {
                Token = userCredential.Token,
                UserName = userCredential.UserName,
                UserId = userDetails.Id,
            };
        }
    }
}

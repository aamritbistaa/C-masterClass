using EmployeeMS.AppDbContext;
using EmployeeMS.Dto.Request;
using EmployeeMS.Dto.Response;
using EmployeeMS.Helpers;
using EmployeeMS.Mapper;
using EmployeeMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeMS.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllUser")]
        public async Task<List<UserResponse>?> GetAllUser()
        {
            var usr = await _context.Users.ToListAsync();

            var userList =
                (from item in usr
                 where item.IsDeleted == false
                 select Mappers.UserToUserResponseMapper(item)).ToList();
            return userList;
        }

        [HttpGet("GetUserById")]
        public async Task<UserResponse?> GetUserById(int id, string password)
        {
            var usr = await _context.Users.ToListAsync();
            var response = usr.Where(x => x.Id == id).FirstOrDefault();
            bool verifyCredential = true;// VerifyPassword(password, response.Password, response.salt);
            if (verifyCredential)
            {
                return Mappers.UserToUserResponseMapper(response);
            }
            return null;
        }

        public static bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            var hashToVerify = HashPasswordWithSalt(password, storedSalt);
            return hashToVerify.SequenceEqual(storedHash);
        }
        [HttpPost("CreateUser")]
        public async Task<UserResponse?> CreateUser(CreateUserRequest request)
        {
            var usr = _context.Users;
            DateOnly requestDate = DateOnly.Parse(request.DateOfBirth);
            DateOnly currentDate = DateTimeHelpers.ReturnTodayDate;

            if (requestDate > currentDate)
            {
                return null;
            }

            var itemWithEmail = usr.FirstOrDefault(x => x.Email == request.Email);
            if (itemWithEmail != null)
            {
                return null;
            }
            /*
             * 
{
  "name": "Amrit Bista",
  "dateOfBirth": "2010-10-10",
  "phoneNumber": "9843804968",
  "gender": "Male",
  "email": "aamritbistaa@gmail.com",
  "uniqueId": "string",
  "addressId": 1,
  "password": "string"
}
             * 
             */
            request.PhoneNumber = request.PhoneNumber.ReturnsActualPhoneNumber();
            var itemWithPhone = usr.FirstOrDefault(x => x.PhoneNumber == request.PhoneNumber);
            if (itemWithPhone != null)
            {
                return null;
            }

            var data = await GetEncryptedPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UniqueId = request.UniqueId,
                Gender = request.Gender,
                AddressId = request?.AddressId,
                Password = data.passwordHash,
                salt = data.salt,

            };
            var userInfo = usr.Add(user);


            await _context.SaveChangesAsync();
            var response = Mappers.UserToUserResponseMapper(user);

            return response;
        }
        [HttpPut("UpdateUser")]
        public async Task<UserResponse?> UpdateUser(UpdateUserRequest request)
        {
            var usr = _context.Users;

            DateOnly requestDate = DateOnly.Parse(request.DateOfBirth);
            DateOnly currentDate = DateTimeHelpers.ReturnTodayDate;

            if (requestDate > currentDate)
            {
                return null;
            }

            var userItem = await _context.Users.FindAsync(request.Id);
            if (userItem == null)
            {
                return null;
            }
            request.PhoneNumber = request.PhoneNumber.ReturnsActualPhoneNumber();
            var item = usr.Where(x => x.Id != request.Id).FirstOrDefault(x => x.Email == request.Email || x.PhoneNumber == request.PhoneNumber || x.UniqueId == request.UniqueId);
            if (item != null)
            {
                return null;
            }

            userItem.Name = request.Name;
            userItem.DateOfBirth = request.DateOfBirth;
            userItem.Email = request.Email;
            userItem.PhoneNumber = request.PhoneNumber;
            userItem.UniqueId = request.UniqueId;
            userItem.Gender = request.Gender;
            userItem.AddressId = request.AddressId;

            usr.Update(userItem);
            await _context.SaveChangesAsync();
            var response = Mappers.UserToUserResponseMapper(userItem);
            return response;
        }
        [HttpDelete]
        public async Task<UserResponse?> DeleteUser(int id)
        {
            var usr = _context.Users;

            var userItem = usr.FirstOrDefault(x => x.Id == id);

            if (userItem == null)
            {
                return null;
            }
            userItem.IsDeleted = true;
            var result = _context.Users.Update(userItem);
            await _context.SaveChangesAsync();
            var response = Mappers.UserToUserResponseMapper(userItem);
            return response;
        }

        [HttpGet("Test")]
        public async Task<(string passwordHash, string salt)> GetEncryptedPassword(string userpassword)
        {
            string password = userpassword;

            // Generate salt
            byte[] salt = GenerateSalt(32);

            var passwordsalt = Encoding.UTF8.GetString(salt);

            // Hash password with salt
            byte[] passwordHash = await Task.Run(() => HashPasswordWithSalt(password, salt));

            var hash = Encoding.UTF8.GetString(passwordHash);

            return (hash, passwordsalt);
        }
        [HttpGet("Test2")]
        public static byte[] GenerateSalt(int size)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[size];
                rng.GetBytes(salt)
;
                return salt;
            }
        }
        [HttpGet("Test1")]
        public static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedBytes = salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray();
                return sha256.ComputeHash(combinedBytes);
            }
        }
    }
}

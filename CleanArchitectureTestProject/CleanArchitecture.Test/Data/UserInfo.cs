

using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Enum;

namespace CleanArchitecture.Test.Data
{
    public class UserInfo
    {
        public static List<User> UserList { get; set; }
        public static User user { get; set; }
        public static List<UserResponse> userResponseList { get; set; }
        public static UserResponse userResponse { get; set; }

        public static void Initialize()
        {
            UserList = new List<User>
            {
                new User
                {
                    Id = 10,
                    Name = "User 1",
                    AddresId = 10,
                    Email = "test123@gmail.com",
                    DateOfBirth ="2001-01-01",
                    PhoneNumber = "+977-9856-23-1256",
                    UniqueId = "012293aksdal-sd2",
                    Gender = GenderEnum.Female,
                    IsDeleted = false,
                },
                new User
                {
                    Id = 11,
                    Name = "User 2",
                    AddresId = 9,
                    Email = "test13@gmail.com",
                    DateOfBirth ="2001-01-01",
                    PhoneNumber = "+1-9856-23-1256",
                    UniqueId = "012293a-asksdal-sd2",
                    Gender = GenderEnum.Male,
                    IsDeleted = false,
                },
                new User
                {
                    Id = 13,
                    Name = "User 3",
                    AddresId = 12,
                    Email = "test233@gmail.com",
                    DateOfBirth ="2011-01-01",
                    PhoneNumber = "+1-0856-23-1256",
                    UniqueId = "012293a-asasdksdal-sd2",
                    Gender = GenderEnum.Female,
                    IsDeleted = true,
                }
            };
            user = new User
            {
                Id = 10,
                Name = "User 1",
                AddresId = 10,
                Email = "test123@gmail.com",
                DateOfBirth = "2001-01-01",
                PhoneNumber = "+977-9856-23-1256",
                UniqueId = "012293aksdal-sd2",
                Gender = GenderEnum.Female,
                IsDeleted = false,
            };
            userResponse = new UserResponse
            {
                Id = 10,
                Name = "User 1",
                AddresId = 10,
                Email = "test123@gmail.com",
                DateOfBirth = "2001-01-01",
                PhoneNumber = "+977-9856-23-1256",
                UniqueId = "012293aksdal-sd2",
                Gender = GenderEnum.Female,
                IsDelted = false,
            };
            userResponseList = new List<UserResponse>
            {
                new UserResponse
                {
                    Id = 10,
                    Name = "User 1",
                    AddresId = 10,
                    Email = "test123@gmail.com",
                    DateOfBirth ="2001-01-01",
                    PhoneNumber = "+977-9856-23-1256",
                    UniqueId = "012293aksdal-sd2",
                    Gender = GenderEnum.Female,
                    IsDelted = false,
                },
                new UserResponse
                {
                    Id = 11,
                    Name = "User 2",
                    AddresId = 9,
                    Email = "test13@gmail.com",
                    DateOfBirth ="2001-01-01",
                    PhoneNumber = "+1-9856-23-1256",
                    UniqueId = "012293a-asksdal-sd2",
                    Gender = GenderEnum.Male,
                    IsDelted = false,
                },
                new UserResponse
                {
                    Id = 13,
                    Name = "User 3",
                    AddresId = 12,
                    Email = "test233@gmail.com",
                    DateOfBirth ="2011-01-01",
                    PhoneNumber = "+1-0856-23-1256",
                    UniqueId = "012293a-asasdksdal-sd2",
                    Gender = GenderEnum.Female,
                    IsDelted = true,
                }
            };


            
        }

    }
}


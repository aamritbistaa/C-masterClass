using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.Mapper
{
    public class UserMapper
    {
        public static User CreateUserRequestToUser(CreateUserRequest request)
        {
            return new User
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                UniqueId = request.UniqueId,
                Gender = request.Gender,
                AddresId = request.AddresId,
            };
        }

        public static UserResponse UserToUserResponse(User request)
        {
            return new UserResponse
            {
                Id = request.Id,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                UniqueId = request.UniqueId,
                Gender = request.Gender,
                AddresId = request.AddresId,
                IsDelted = request.IsDeleted
            };
        }
    }
}
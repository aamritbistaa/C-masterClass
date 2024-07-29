using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper
{
    internal class UserMapper
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
    }
}
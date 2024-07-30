using CleanArchitecture.Domain.Enum;
using CleanArchitecture.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTO.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UniqueId { get; set; }
        public GenderEnum Gender { get; set; }
        public int? AddresId { get; set; }
        public bool IsDelted { get; set; }
    }
}

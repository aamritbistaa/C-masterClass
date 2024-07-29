using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Enum;
using CleanArchitecture.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTO.Request
{
    public class CreateUserRequest
    {
        [CustomNameValidation]
        public string Name { get; set; }
        [CustomFutureDateValidation]
        public string DateOfBirth { get; set; }
        [CustomEmailValidation]
        public string Email { get; set; }
        [CustomPhoneNumberValidation]
        public string PhoneNumber { get; set; }
        [Required]
        public string UniqueId { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }

        public int? AddresId { get; set; }
    }
    public class UpdateUserRequest
    {
        [Required]
        public int Id { get; set; }
        [CustomNameValidation]
        public string Name { get; set; }
        [CustomFutureDateValidation]
        public string DateOfBirth { get; set; }
        [CustomEmailValidation]
        public string Email { get; set; }
        [CustomPhoneNumberValidation]
        public string PhoneNumber { get; set; }
        [Required]
        public string UniqueId { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }

        public int? AddresId { get; set; }
    }
}

using EmployeeMS.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Dto.Request
{
    public class CreateUserRequest
    {
        [CustomNameValidator]
        public string Name { get; set; }
        [CustomFutureDateValidator]
        public string DateOfBirth { get; set; }
        [CustomPhoneNumberValidation]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [AllowedValues(typeof(string),"Male","Female")]
        public string Gender { get; set; }
        [CustomEmailValidation]
        public string Email { get; set; }
        [Required(ErrorMessage = "UniqueId is requried")]
        public string UniqueId { get; set; }
        public int? AddressId { get; set; }
        public string Password { get; set; }
    }
    public class UpdateUserRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 10, ErrorMessage = "Length Of Name must be in range 10, 50.")]
        [RegularExpression(@"^[a-zA-Z]+( [a-zA-Z]+)*$")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^20\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-2])$", ErrorMessage = "Date must be in format 20xx-12-01.")]
        public string DateOfBirth { get; set; }
        [Required]
        [RegularExpression(@"((\+977|\+1)?-?)?\d{4}-?\d{2}-?\d{4}", ErrorMessage = "Mobile no not in format +977-xxxx-xx-xxxx or +1-xxxx-xx-xxxx or +977xxxxxxxxxx or +1xxxxxxxxxx.")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^\w{5,30}@(gmail|facebook|technofex)\.(com|np|gov)$", ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Gender is required.")]
        [AllowedValues(typeof(string), "Male", "Female")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "UniqueId is requried.")]
        public string UniqueId { get; set; }
        [Required(ErrorMessage = "AddressId is requried.")]
        public int AddressId { get; set; }

    }
}

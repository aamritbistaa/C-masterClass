using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Dto.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string UniqueId { get; set; }
        public int? AddressId { get; set; }
        public string Password { get; set; }
    }
}

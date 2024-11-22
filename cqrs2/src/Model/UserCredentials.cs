using System.ComponentModel.DataAnnotations;

namespace CQRSApplication.Model
{
    public class UserCredentials
    {
        [Key]
        public Guid Id { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov|np|edu)$", ErrorMessage = "Invalid pattern.")]        
        public string Email { get; set; }
        
        [Required(ErrorMessage ="User name is required and be of max length 20"), MaxLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public RoleType Role { get; set; } = RoleType.Customer;
        public string? Token { get; set; }
        public bool IsActive { get; set; }
    }
    public enum RoleType
    {
        SuperAdmin,
        Vendor,
        Customer
    }
}

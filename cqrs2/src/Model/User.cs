using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSApplication.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required and be of max length 20"), MaxLength(20)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required and be of max length 20"), MaxLength(20)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Phone number is required and be of max length 15"), MaxLength(15)]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "User name is required and be of max length 200"), MaxLength(200)]
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
        //to link user table with userRole
        public Guid UserCredentialsId { get; set; }
        //used for navigating
        [ForeignKey("UserCredentialsId")]
        public virtual UserCredentials? userCredentials { get; set; }
        public Guid? ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        public virtual ShippingAddress? shippingAddress { get; set; }
        [ForeignKey("CartId")]
        public Guid? CartId { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}

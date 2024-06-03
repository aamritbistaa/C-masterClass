using System.ComponentModel.DataAnnotations;

namespace WebApiContactBookList.Models
{
    public class ContactModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string EmailAddress1 { get; set; } = string.Empty;

        [StringLength(20)]
        public string? EmailAddress2 { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber1 { get; set; } = string.Empty;
        [StringLength(10)]

        public string? PhoneNumber2 { get; set; }

    }
}

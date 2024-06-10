using System.ComponentModel.DataAnnotations;

namespace CRUD_with_auth.Models.Dtos
{
    public class UserRegistrationRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
       
        [Required]
        public string Password { get; set; }

    }
}

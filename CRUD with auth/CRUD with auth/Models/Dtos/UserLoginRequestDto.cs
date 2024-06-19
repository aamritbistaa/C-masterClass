using System.ComponentModel.DataAnnotations;

namespace CRUD_with_auth.Models.Dtos
{
    public class UserLoginRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Dto.Request
{
    public class CreateAddressRequest
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
    public class UpdateAddressRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}

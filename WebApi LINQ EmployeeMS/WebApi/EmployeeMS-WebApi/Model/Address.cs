using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Model
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}

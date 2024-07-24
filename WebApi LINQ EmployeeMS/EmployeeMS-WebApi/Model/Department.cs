using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Model
{
    public class Department
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}

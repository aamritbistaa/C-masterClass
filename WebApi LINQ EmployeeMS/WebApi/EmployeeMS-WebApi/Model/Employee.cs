using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMS.Model
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        public virtual Department? Department { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}

using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entity
{
    public class Employee : BaseEntity
    {
        [Required]
        public string Position { get; set; }
        [Required]
        public double Salary { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}

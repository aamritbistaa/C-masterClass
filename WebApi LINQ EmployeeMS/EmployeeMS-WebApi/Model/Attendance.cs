using EmployeeMS.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMS.Model
{
    public class Attendance
    {
        [Required]
        public int Id { get; set; }
        public DateOnly Date { get; set; } = DateTimeHelpers.ReturnTodayDate;
        [Required]
        public TimeOnly InTime { get; set; }    
        public TimeOnly? OutTime { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmployeeMS.Validation;

namespace EmployeeMS.Dto.Request
{
    public class CreateAttendanceRequest
    {
        [CustomFutureDateValidator]
        public string Date { get; set; }
        [CustomTimeValidator]
        public string InTime { get; set; }
        [CustomTimeValidator]
        public string? OutTime { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
    public class UpdateAttendanceRequest
    {
        [Required]
        public int Id { get; set; }
        [CustomFutureDateValidator]
        public string Date { get; set; }
        [CustomTimeValidator]
        public string InTime { get; set; }
        [CustomTimeValidator]
        public string? OutTime { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}

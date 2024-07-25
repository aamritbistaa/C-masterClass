using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Dto.Request
{
    public class CreateEmployeeRequest
    {
        [Required]
        public string Position { get; set; }
        [Required]
        public float Salary { get; set; }
        public int? DeptId { get; set; }
        public int? UserId { get; set; }
    }
    public class UpdateEmployeeRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public int DeptId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}

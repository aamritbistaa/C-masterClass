using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Dto.Request
{
    public class CreateDepartmentRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class UpdateDepartmentRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

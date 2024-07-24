using EmployeeMS.Model;

namespace EmployeeMS.Dto.Response
{
    public class GetAllEmployeeRecordResponse
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DateOfBirth { get; set; }
        public float? Salary { get; set; }
        public string? Position { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? DepartmentName { get; set; }
        public List<AttendanceResponse>? Attendances { get; set; } 
    }
}

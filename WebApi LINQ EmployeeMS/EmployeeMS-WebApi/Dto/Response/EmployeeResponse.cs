namespace EmployeeMS.Dto.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }
        public bool IsDeleted { get; set; }
        public int? DepartmentId { get; set; }
        public int? UserId { get; set; }
    }
}

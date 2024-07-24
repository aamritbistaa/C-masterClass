namespace EmployeeMS.Dto.Response
{
    public class AttendanceResponse
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly InTime { get; set; }
        public TimeOnly? OutTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}

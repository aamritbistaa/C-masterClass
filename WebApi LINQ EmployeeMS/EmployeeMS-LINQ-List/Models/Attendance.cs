namespace EmployeeMS_LINQ_List.Models
{
    public class Attendance
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int EmpId { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public DateOnly TodayDate { get; } = Helpers.GetTodayDate();
    }
}
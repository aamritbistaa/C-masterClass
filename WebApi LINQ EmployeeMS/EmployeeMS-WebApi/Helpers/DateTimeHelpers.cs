namespace EmployeeMS.Helpers
{
    public class DateTimeHelpers
    {
        public static DateOnly ReturnTodayDate = DateOnly.Parse(DateTime.UtcNow.ToShortDateString());

        public static TimeOnly ReturnCurrentTime = TimeOnly.Parse(DateTime.UtcNow.ToShortTimeString());
    }
}

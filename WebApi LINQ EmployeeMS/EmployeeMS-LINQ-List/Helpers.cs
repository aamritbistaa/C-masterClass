namespace EmployeeMS_LINQ_List
{
    public static class Helpers
    {
        public static DateOnly GetTodayDate()
        {
            DateTime today = DateTime.Today;
            var todayDate = today.ToShortDateString();
            return DateOnly.Parse(todayDate);
        }
    }
}
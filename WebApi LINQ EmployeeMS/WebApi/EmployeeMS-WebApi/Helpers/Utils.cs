namespace EmployeeMS.Helpers
{
    public static class Utils
    {
        public static string ReturnsActualPhoneNumber(this string data)
        {
            if (data.StartsWith("+1"))
            {
                data = data.Substring(2);
            }
            else if (data.StartsWith("+977"))
            {
                data = data.Substring(4);
            }

            var items = data.Split('-');
            data = string.Join("", items);

            return data;
        }
    }
}

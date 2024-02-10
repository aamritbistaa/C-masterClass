
using Microsoft.VisualBasic;

TimeOnly opensAt = TimeOnly.Parse("8:00AM");
Console.WriteLine(opensAt);

DateTime currentDateTime = DateTime.Now;

TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

Console.WriteLine($"Current DateTime is {currentDateTime}");
Console.WriteLine($"Current Time is {currentTime}");
Console.WriteLine($"Current Date is {currentDate}");

Console.WriteLine($"Extracted date part is {currentDateTime.ToString("dd/MM/yyyy")}");
Console.WriteLine($"Extracted time part is {currentDateTime.ToString("HH:mm:ss")}");

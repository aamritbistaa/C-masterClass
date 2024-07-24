
using System.Globalization;

DateTime todayVariable = DateTime.Now; // gives local time 
//Stores fulltime -> 2/11/2024 1:17:08 AM
Console.WriteLine(todayVariable);
Console.WriteLine(DateTime.UtcNow);

Console.WriteLine(todayVariable.ToString(format: "M")); //Returns month
Console.WriteLine(todayVariable.ToString(format: "d")); //Returns date

DateTime birthDate = DateTime.Parse("01/23/2001");
//DateTime birthDate = DateTime.ParseExact("23/01/2001", "d/M/yyyy", CultureInfo.InvariantCulture);
Console.WriteLine(birthDate.ToString());


Console.WriteLine(todayVariable.ToString(format: "MMMM dd, yyyy hh:mm tt zzz"));

var variable = DateTime.Now.Date;



// Local time
// 7 / 23 / 2024 1:26:58 PM
Console.WriteLine(DateTime.Now);

// UTC current time
// 7/ 23 / 2024 7:41:58 AM
Console.WriteLine(DateTime.UtcNow);



System.Console.WriteLine($"Only date {DateTime.Now.ToString("yyyy-MM-dd")}."); //    -> 2024-07-23.

System.Console.WriteLine($"Only Local time {DateTime.UtcNow.ToShortTimeString()}"); //    -> 1:41 PM
System.Console.WriteLine($"Short TIme string time {DateTime.Now.ToShortTimeString()}"); //   -> 1:41 PM

System.Console.WriteLine($"Only Local time {DateTime.Now.Kind}"); //   -> Local or UTC



System.Console.WriteLine(DateTime.Now.DayOfWeek); //Gives weekDay -> Tuesday

System.Console.WriteLine(DateTime.Now.DayOfYear); //Gives day of the year -> 205
System.Console.WriteLine(DateTime.Now.Day); //Gives date -> 23

System.Console.WriteLine(DateTime.UtcNow.ToShortDateString());

Console.ReadLine();
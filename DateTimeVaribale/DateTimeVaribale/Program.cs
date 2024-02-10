
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
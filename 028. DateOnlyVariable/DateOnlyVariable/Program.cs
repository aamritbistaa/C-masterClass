
DateOnly birthDate = DateOnly.Parse("01/23/2001");

Console.WriteLine($"Unformated date {birthDate}");

Console.WriteLine($"Formatted Date {birthDate.ToString(format: "MMMM dd,yyyy")}");

DateTime today = DateTime.Now;
Console.WriteLine($"Todays full date {today}");
Console.WriteLine($"Todays just date:{today.Date}");

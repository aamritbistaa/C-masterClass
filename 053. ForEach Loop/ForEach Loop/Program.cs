
string data = "Amrit,Ram,Hari,ASJ";

List<string>firstNames = data.Split(',').ToList();

foreach (string firstName in firstNames)
{
    Console.WriteLine($"Hello {firstName}");
}
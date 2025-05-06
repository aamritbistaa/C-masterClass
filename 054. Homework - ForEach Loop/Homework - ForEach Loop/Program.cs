//Ask the user for their first name. Continue asking for first names until there are no mre.
//Then loop through each name using foreach and tell each person hello on the Console.

List<string> firstNames = new List<string>();

string choice = "y";
do
{
    Console.WriteLine("Enter first name");
    string data = Console.ReadLine();
    if (data.Trim() != null)
    {
        firstNames.Add(data.Trim());
    }
    Console.WriteLine("Do you want to exit? Press (N/n) to exit");
    choice = Console.ReadLine().Trim();
} while (choice.ToLower() != "n");


foreach (string name in firstNames)
{
    Console.WriteLine($"Hello {name}");
}
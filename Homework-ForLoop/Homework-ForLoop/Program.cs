//Ask the user for a comma-separated list of first names (no space).
//Split the string into a string array. Loop through the array and 
//print "Hello <name>" to the Console for each person


string inputText = string.Empty;

Console.WriteLine("Enter the name of person seperated by ','");
do
{
inputText = Console.ReadLine().Trim();
}while (inputText == string.Empty);

//Array nameArray = inputText.Split(',');
List<String> nameArray = inputText.Split(',').ToList();

Console.WriteLine($"input Text is {inputText} ");

foreach (string name in nameArray)
{
    Console.WriteLine($"Hello {name.Trim()}");
}

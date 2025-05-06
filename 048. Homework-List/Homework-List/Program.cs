//Add students to  class roster List until there are no more students.
//Then print the count to the Console

List<string> nameClass = new List<string>() {"sample" };
string input;

do
{
    Console.WriteLine("Enter the name of student or Q to quit");
    input = Console.ReadLine().Trim();
    if (input == "Q") break;

    if (input.Length > 0)
    {
        nameClass.Add(input);
    }

}while (true);

foreach (string name in nameClass)
{
    Console.WriteLine(name);
}
Console.WriteLine(nameClass.Count);

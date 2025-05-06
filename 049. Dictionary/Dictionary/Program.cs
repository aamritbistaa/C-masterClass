

Dictionary<int,string> lookup = new Dictionary<int, string>()
{
    {1,"Ram" },{2,"Hari"},{928,"Amrit"}
};
string numText;
do
{
    int num;
    Console.WriteLine("Enter your choice");
    numText = Console.ReadLine();
    bool isValidNum = int.TryParse(numText, out num);
    if (isValidNum && lookup.ContainsKey(num))
    {
        Console.WriteLine($"key{num} is {lookup[num]}");
    }
    else
    {
        Console.WriteLine("doesnot has the input as key");
    }
} while (numText != "Q");


Dictionary<string, int> weekDay = new Dictionary<string, int>()
{
    {"Sun",1 },
    {"Sat",7 }
};
weekDay.Add( "Fri",6);

Console.WriteLine($"{weekDay["Fri"]}");
//Create a Dictionary list of employee IDs and the name that goes with the ID.
//Fill in a few records. Then ask the user for their ID and return their name.

Dictionary<int,string> employees = new Dictionary<int, string>() { {10,"Ramesh" } };
string Choice;
do
{
    Console.WriteLine("Enter 'Quit' if you want to quit \n'Add' to add \n'Display All' to display all \n'Single' to display with respect to key ");
    Choice = Console.ReadLine().Trim();

    if (Choice.ToLower() == "quit") break;
    
    else if (Choice.ToLower() == "display all")
    {
        foreach (var item in employees)
        {
            Console.WriteLine($"{item.Key},{item.Value}");
        }
    }
    
    else if (Choice.ToLower() == "add")
    {
        Console.WriteLine("Enter id");
        bool isValidID= int.TryParse(Console.ReadLine().Trim(), out int id);
        if (isValidID == false) break;
        Console.WriteLine("Enter employee name");
        string name =Console.ReadLine();
        employees.Add(id, name);
    }
    else if (Choice.ToLower() == "single")
    {
        Console.WriteLine("Enter id");
        bool isValidID = int.TryParse(Console.ReadLine().Trim(), out int id);
        if (isValidID == false) break;
        if (employees.ContainsKey(id))
        {
            Console.WriteLine($"{id} : {employees[id]}");
        }
        else
        {
            Console.WriteLine("Key doesnot exist in the collection");
        }
    }
    
    else
    {
        Console.WriteLine("Please Enter valid option");
    }
    Console.WriteLine("\n\n");

} while (true);
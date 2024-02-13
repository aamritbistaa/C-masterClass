
string firstName = "ramesh";
int age = 23;

switch (firstName.ToLower())
{
    case "amrit" or "ramesh":
        Console.WriteLine("admin");
        break;

    case "ram":
        Console.WriteLine("user");
        break;

    default: 
        Console.WriteLine("Cant find the user please register");
        break;
}

switch (age)
{
    case >= 0 and < 18:
        Console.WriteLine("Child");
        break;
    case >= 18 and < 30:

        Console.WriteLine("teen");
        break;
    case >= 30 and < 40:
        Console.WriteLine("Man");
        break;
    default:
        Console.WriteLine("Age cant be identified");
        break;
}
//Create a Console Application that asks the user for their name. Welcome me
//(Tim) as professor or anyone else as student. Make sure that "TIM" also gets
//called as professor
//check for tim or tim athy
Console.WriteLine("Enter your first name ");
string? firstName = Console.ReadLine();
Console.WriteLine("Enter your last name ");
string? lastName = Console.ReadLine();

if(firstName.ToUpper() =="TIM" && lastName.ToLower() == "athy")
{
    Console.WriteLine("Welcome Professor");
}
else
{
    Console.WriteLine("Welcome Student");
}

switch (firstName.ToLower())
{
    case "tim":
        Console.WriteLine("Welcome professor");
        break;
    default:
        Console.WriteLine("welcome student");
        break;
}

switch (firstName.ToLower() +" "+ lastName.ToLower())
{
    case "tim athy":
        Console.WriteLine("Hello Professor");
        break;
    default:
        Console.WriteLine("hello student");
        break;
}
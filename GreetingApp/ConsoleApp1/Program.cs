//Welcome User To App
Console.WriteLine("Welcome to this App");

//Ask for First Name
string firstName;
do
{

    Console.WriteLine("Enter your first Name");
    firstName = Console.ReadLine();

} while (firstName.Trim().Length > 20);
//Greet user by name
Console.WriteLine("Hello "+ firstName);
Console.WriteLine("Hello {0}" ,firstName);

Console.WriteLine("Thank you!");
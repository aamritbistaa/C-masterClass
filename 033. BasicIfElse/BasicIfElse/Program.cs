
bool isComplete = false;

if (isComplete)
{
    Console.WriteLine("Statement is true");
    Console.WriteLine("this part of code only runs if the condition is true");
}
else
{ 
    Console.WriteLine("Statement is false");
    Console.WriteLine("this part of code only runs if the condition is false");
}
Console.WriteLine("End of Program");


Console.WriteLine("Enter first name:");
string? firstName = Console.ReadLine();

//if (firstName.ToLower() == "amrit")
if (firstName.ToUpper() == "AMRIT")
{
    Console.WriteLine("Hello Amrit welcomeback");
}
else
{
    Console.WriteLine($"Hello {firstName}");
}

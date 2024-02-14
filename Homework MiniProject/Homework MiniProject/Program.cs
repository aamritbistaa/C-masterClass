//Console app that asks a user for their name and age.
//if name is bob or sue, address them as professor.
//if the person is under 21, recommend thy wait x years to start this class

string? name;
int age;
bool isValidAge;
do
{
 Console.WriteLine("Enter your name: ");
 name= Console.ReadLine().Trim();
}while(name==null);


Console.WriteLine("Enter your age: ");
if(isValidAge = int.TryParse(Console.ReadLine(), out age) == false)
{
    Console.WriteLine("Invalid age \nExiting...");
    return;
}




if (name.ToLower() == "bob" || name.ToUpper() == "SUE")
{
    name = "Professor"+" " + name;
}

if (age > 21)
{
        Console.WriteLine($"Hello {name}, welcome to university");
}
else
{
    Console.WriteLine($"Hello {name}, you have to wait {21 - age}");
}

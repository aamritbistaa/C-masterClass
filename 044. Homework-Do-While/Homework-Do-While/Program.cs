//Create a Console App that asks for their name.
//Welcome Tim as professor or anyone else as student.
//Do this until the user types "exit"

using System.Xml.Linq;

bool isContinue = true;

while (isContinue) 
{
    Console.WriteLine("Enter your name");
    string name = Console.ReadLine().Trim();
    if (name.Length > 0)
    {

    if (name.ToLower() == "tim")
    {
        Console.WriteLine("Hello Professor");
    }
    else if(name.ToLower() == "exit")
    {
        Console.WriteLine("Quitting....");
        isContinue = false;
    }
    else
    {
        Console.WriteLine($"Hello student{name}");
        }
    }

}


{
string name;
do
{
    Console.WriteLine("Enter your name, 'exit' to quit");
    name = Console.ReadLine().Trim();
    if (name.Length > 0){

    if (name.ToLower() == "tim")
    {
        Console.WriteLine("Hello Professor");
    }
    else if (name.ToLower() != "exit")
    {
        Console.WriteLine("Hello student");
    }

        }

    } while (name.ToLower() != "exit");
}
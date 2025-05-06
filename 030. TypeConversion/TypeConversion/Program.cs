
Console.WriteLine("Enter your Age");
string? ageStr = String.Empty;
bool isValidInt=true;
int age;
do
{
    ageStr = Console.ReadLine();
    //int age = int.Parse(ageStr); //Parse strictly converts input to int so if string is entered, it throws error
    isValidInt = int.TryParse(ageStr, out  age); // this takes input and passes output to age and if success, this returns true else returns false because of which we can see if this is valid
    if (isValidInt == false)
    {
        Console.WriteLine("Enter valid input");
    }
} while (!isValidInt);

Console.WriteLine($"You entered the valid input and the age after 15 years is {age + 15}");


double ageDouble = age;
decimal testDecimal = (decimal)age;
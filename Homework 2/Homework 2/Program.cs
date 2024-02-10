//Capture a user's age from the Console and then identify how old they will be in 25 years,
//as well as how old the were 25 years ago. Print That information to the console in natural
//language

Console.WriteLine("Enter your age");
int age;
bool isValidInput = false;
do
{
    string userInput = Console.ReadLine();
    isValidInput=int.TryParse(userInput, out age);

    if (isValidInput == false)
    {
        Console.WriteLine("You entered an invalid input,\nPlease Enter again!");
    }

} while (!isValidInput);
Console.WriteLine($"Current age is {age}");
if (age - 25 < 0)
{
    Console.WriteLine("Your were not born before 25 years");
}
else
{
    Console.WriteLine($"Your Age before 25 years was {age - 25}");
}
Console.WriteLine($"Your Age after 25 years will be {age + 25}");

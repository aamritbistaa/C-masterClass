//Create a Console Application that has variables to hold a person's name,age if they are alive
//and their phone number. You do not need to capture these values from the user.

string? name = null;
int? age = null;
bool? isAlive = null;
string?phoneNumber = null;

name = "Amrit Bista";
phoneNumber = "+977-2123123";
isAlive = true;
if (isAlive == true)
{
    age = 70;
}

Console.WriteLine($"{name} is {age} and his phone number is {phoneNumber}");

//Create an array of 3 names. Ask the user which number to select.
//When the user gives you a number, return that name.
//Make sure to check for invalid numbers

string[] names = new string[] { "amrit", "Ram", "Hari" };
bool isValidNumber;
string choiceText;

do
{


    Console.WriteLine("Enter your choice of index");
    choiceText = Console.ReadLine().Trim();
    isValidNumber = int.TryParse(choiceText, out int number);

    if (isValidNumber&&number >= 0 && number <= names.Length - 1)
    {
        Console.WriteLine(names[number]);
    }


} while (choiceText != "exit");
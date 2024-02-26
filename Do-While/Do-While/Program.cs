/*
bool isValid;
int age;
do
{
    Console.WriteLine("Enter you age");
    string ageText = Console.ReadLine();

    //int age=int.Parse(ageText);


    isValid = int.TryParse(ageText, out age);
} while (!isValid);
*/

int num = 20;

do
{
    num = num - 5;
    Console.WriteLine(num);
} while (num > 0);




do
{
    //run and check
    num = num + 5;
    Console.WriteLine(num);
} while (num < 33);

num = 0;
while (num < 28)
{
    num = num + 5;
    Console.WriteLine(num);
}
//while (isValid)
//{
//    Console.WriteLine("while loop");

//    Console.WriteLine("Hello world");
//};
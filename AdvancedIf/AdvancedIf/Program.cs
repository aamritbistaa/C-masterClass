
//Console.WriteLine("Enter your first name: ");
//string? firstName= Console.ReadLine();

//Console.WriteLine("Enter your last name: ");
//string? lastName= Console.ReadLine();

//if (firstName.ToLower() == "amrit" && lastName.ToUpper() == "BISTA")
//{
//    Console.WriteLine("Welcome Amrit your are the main man");
//} else if (firstName.ToLower() == "amrit")
//{
//    Console.WriteLine("You have a familar first name");
//}
//else if (lastName.ToLower() == "bista")
//{
//    Console.WriteLine("You have a familar last name");
//}
//else
//{
//    Console.WriteLine($"Hello {firstName} {lastName} \nplease register before you proceed");
//}
////----------ANtoher---------

//if(firstName.ToLower() == "amrit")
//{
//    Console.WriteLine("Hello Amrit");
//    Console.WriteLine("First condition matched hence wont change another");
//}else if (lastName.ToLower() == "bista")
//{
//    Console.WriteLine("Hello bista");
//    Console.WriteLine("Second condtion matched and will not change the below cases");
//}
//else
//{
//    Console.WriteLine("Match not found");
//}

int salary = 30;
if (salary > 20 && salary<29)
{
    Console.WriteLine("Justifiable");
}
else if( salary > 30 && salary < 49)
{
    Console.WriteLine("more");
}
else
{
    Console.WriteLine("Cant say");
}

if((salary>40 && salary<60)||(salary>80 && salary < 100)){
    Console.WriteLine("Happy");
}
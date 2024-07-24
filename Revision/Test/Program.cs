using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Recursion;
using Test;
using static Test.Linq;



/*
//* Right Shifting
int a = 5;
 //* 101 -> 5
 //* 010 -> 2
 //* 001 -> 1
Console.WriteLine(a);
a = a >> 1;
Console.WriteLine(a);
*/

/*
//* Left Shifting
int a = 5;
//* 000101
//* 001010 -> 10
//* 010100 -> 20
//* 101000 -> 40

a = a << 3;
Console.WriteLine(a);
*/
/*
int firstNumber = 5;
int secondNumber = 10;

if (firstNumber == secondNumber)
{
    Console.WriteLine("first and second number are equal");
}
else if (secondNumber > firstNumber)
{
    Console.WriteLine("Second Number is greater than First Number");
}
else if (firstNumber > secondNumber)
{
    Console.WriteLine("First Number is greater than Second Number");

}
else
{
    Console.WriteLine("Invalid comparision");
}
    Console.ReadKey();
*/


/*
//* Property and field
PropertyAndField.PropertyAndFieldMainFunction();
*/


/*
//* ControlFlow
ControlFlow controlFlow = new ControlFlow();
controlFlow.GoToFunction();
controlFlow.BreakImplementation();
System.Console.WriteLine("hellowlrd");
*/


/*
//* Value and reference type

int number = 20;
ValueAndReferenceDataType ob = new ValueAndReferenceDataType();

Console.WriteLine($"Number before: {number}");
ob.IncreaseByValue(number);
Console.WriteLine($"Number after calling the PassByValue type function: {number}");

Console.WriteLine($"Number before: {number}");
ob.IncreaseByReference(ref number);
Console.WriteLine($"Number after calling the PassByValue type function: {number}");
*/


/* 
//* Recursion
RecursionProgram program = new RecursionProgram();
program.MainFunction();
*/


/*
//* Function
FunctionsType program = new FunctionsType();
program.MainFunction();
*/

/*
//* Static
StaticProperty program = new StaticProperty();
program.MainFunction();
*/

/*
//* ThisPointer
ThisPointer program = new ThisPointer();
program.MainFunction();
*/

//BoxingUnboxing program = new BoxingUnboxing();
//program.MainFunction();

//int a = 5;

// DateTime dateTime= DateTime.Now;

// Console.WriteLine(dateTime);
// Console.WriteLine(DateTime.UtcNow);

/*
//* LinQ
Linq obj = new Linq();
obj.MainFunction();

*/
//LinqClass obj = new LinqClass();
//obj.MainFunction();

/*
//* Regular Expression
RegEx reg = new RegEx();
reg.MainFunction();
*/

/*
//* Deligates
Delegates obj = new Delegates();
obj.MainFunction();
*/

/*
//* File Handling
FileHandling obj = new FileHandling();
obj.MainFunction();
*/

/*
//* Generics
Generics obj = new Generics();
obj.MainFunction();
*/

//Test1 obj = new Test1();
//obj.MainFunction();

//var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//var has5 = items.Contains(5); //true
//var isGreaterThanZero = items.All(x => x > 0); //true
//var isAny = items.Any(x => x > 10); //false

InnerClass obj = new InnerClass();
obj.MainFunction();




//var averageStudentAge = listOfStudent.Average(x => x.Age);
//var totalNumberOfStudent = listOfStudent.Count();



//Console.ReadLine();
//* Events
//Events obj = new Events();
//obj.MainFunction();


//*OOP
//OOP obj = new OOP();
//obj.MainFunction();
//Protection obj = new Protection();
//obj.MainFunction();

//ReadOnlyAndStatic obj = new ReadOnlyAndStatic();
//obj.MainFunction();


/*
//* Binary Operator
int firstNumber = 2;
int secondNumber = 3;
// And
System.Console.WriteLine(firstNumber & secondNumber); //2
// Or
System.Console.WriteLine(firstNumber | secondNumber); //3
// Not
// ~5 = -6
// ~6 = -7
// ~(-5) = 4
System.Console.WriteLine(~7); //-3

// XOr
// 11
// 10
// 01
System.Console.WriteLine(firstNumber ^ secondNumber); //1

// Left Shifting
// left shift 5 by 2
// 00101
// 01010
// 10100
System.Console.WriteLine(5 << 2); //20

// Right Shifting
// Right shift 5 by 2
// 101
// 010
// 001
System.Console.WriteLine(5 >> 2); //1
*/
/*
//* Overloading
Overloading obj = new Overloading();
obj.MainFunction();

*/
/*
//*AccessModifier
AccessModifier obj = new AccessModifier();
obj.MainFunction();
*/

/*
Write a program that prints three numbers in three virtual columns
on the console. Each column should have a width of 10 characters and
the numbers should be left aligned. The first number should be an
integer in hexadecimal; the second should be fractional positive; and
the third – a negative fraction. The last two numbers have to be
rounded to the second decimal place.
*/
/*
int firstNumber = int.Parse(Console.ReadLine());
int secondNumber = int.Parse(Console.ReadLine());

for (int startingNumber = firstNumber; firstNumber <= secondNumber; startingNumber++)
{
    if (startingNumber % 5 == 0)
    {
        System.Console.WriteLine(startingNumber);
    }
}
*/

/*
//* Fibonacci squence

int firstNumber = 0;
int secondNumber = 1;
int thirdNumber = 0;
for (int i = 0; i < 100; i++)
{
    System.Console.WriteLine(firstNumber);
    thirdNumber = firstNumber + secondNumber;
    firstNumber = secondNumber;
    secondNumber = thirdNumber;
}
*/
/*
float sum = 0;
for (int i = 1; i < 100; i++)
{
    sum = sum + (float)1 / i;
}
System.Console.WriteLine("{0:F2}", sum);

System.Console.WriteLine(0 ^ 1);
System.Console.WriteLine(2 < 3);
System.Console.WriteLine(4 > 3);
Console.WriteLine("Exclusive OR: " + ((2 < 3) ^ (4 > 3)));
*/

// int i = 1;
// switch (i)
// {
//     case 0:
//         System.Console.WriteLine("0 is your choice");
//         break;
//     case 1:
//         System.Console.WriteLine("1 is your choice");
//         break;
//     default:
//         System.Console.WriteLine("Your choice is not in the options");
//         break;
// }

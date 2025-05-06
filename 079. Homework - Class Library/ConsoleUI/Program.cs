// See https://aka.ms/new-console-template for more information

//Build a .NET Standard class library and a Console application. Put a couple 
//calculation methods in it and call it from the Console.

using System.ComponentModel;
using ClassLibrary;

Console.WriteLine("Hello, World!");
Console.WriteLine(Calculation.Add(5,10));

Console.WriteLine(Calculation.Add("Ram", "SEY"));

Console.WriteLine(Calculation.Multiply(10,20.4));
Console.WriteLine(Calculation.Difference(19,20));

Console.ReadLine();
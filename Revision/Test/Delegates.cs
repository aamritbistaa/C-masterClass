using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b) { return a * b; }

        public int Modulo(int a , int b) { return a % b; }
    }

    public class Greet
    {
        public void SayGoodMorning(string name)
        {
            Console.WriteLine($"Good Morning {name}");
        }
        public void SayGoodNight(string name)
        {
            Console.WriteLine($"Good Night {name}");
        }
    }

    internal class Delegates
    {
        delegate int MathOperation(int a, int b);

        delegate void StringDelegate(string text);

        static void ToUpperCase(string text)
        {
            Console.WriteLine(text.ToUpper());
        }
        static void ToLowerCase(string text) => Console.WriteLine(text.ToLower());

        static void WriteOutput(string text, StringDelegate stringDelegate)
        {
            Console.WriteLine($"Before: {text}");
            stringDelegate(text);
        }
        delegate void Greetings(string name);

        public void MainFunction()
        {
            //Calling methods inside same class
            StringDelegate stringDel = ToUpperCase;
            stringDel("textToConvert");

            stringDel = ToLowerCase;
            stringDel("textToConvert");

            //Passing Delegates
            WriteOutput("this is lower", stringDel);


            //Creating Calculator Object
            Calculator CalculatorObj = new Calculator();

            //Substituting Method inside of Calculator object to delegate
            MathOperation operation = null;

            operation = CalculatorObj.Add;
            int result1 = operation(10, 20);
            Console.WriteLine(result1);

            operation = CalculatorObj.Multiply;
            int result2 = operation(10, 20);
            Console.WriteLine(result2);

            //To invoke both the method
            Console.WriteLine("Multicast delegates");

            Greet greet = new();
            Greetings greetings = null;
            greetings += greet.SayGoodMorning;

            greetings = greetings + greet.SayGoodNight;

            greetings("Amrit");

        }


    }
}

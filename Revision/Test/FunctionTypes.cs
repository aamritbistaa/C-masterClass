using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    static class StaticHelpers
    {
        //extension method
        public static void SayHello(this string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        public static void AboutMe(this string name, string message)
        {
            Console.WriteLine($"Hello, {name}, \n{message}");
        }
        public static string Car(this string name, int engine) 
        {
            return $"{name} has an engine capacity of {engine}";
        }
    }
    public class InstaciatedHelper
    {
        public static void SayGoodMorning(string name)
        {
            Console.WriteLine($"Good Morning, {name}");
        }
        public void SayGoodEvening(string name)
        {
            Console.WriteLine($"Good Evening, {name}");
        }

    }
    internal class FunctionsType
    {
        //Function with argument and with return values
        int AddTwoNumber(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        //Function with argument and without return values
        void MultiplyTwoNumber(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber*secondNumber);
        }
        void Greet(string name)
        {
            Console.WriteLine($"Good Morning, {name}");
        }
        //Function without arugment and with return values 
        private int _empNumber = 10239;
        int ReturnEmployeeNumber()
        {
            return _empNumber;
        }
        //function without argument and without return values
        void DisplayEmployeeNumber()
        {
            Console.WriteLine(_empNumber);
        }

        public void MainFunction()
        {
            var sumOfTwoNumber = AddTwoNumber(1, 2);
            Console.WriteLine(sumOfTwoNumber);
            MultiplyTwoNumber(10, 20);
            Greet("Ramesh");
            var empNumber = ReturnEmployeeNumber();
            DisplayEmployeeNumber();


            //Calling a static method
            InstaciatedHelper.SayGoodMorning("Amrit");
            //Calling method in different class
            InstaciatedHelper instanObj = new InstaciatedHelper();
            instanObj.SayGoodEvening("Amrit");

            //Calling an extension method
            "Amrit".SayHello();
            //Calling an extension method and passing value
            "Amrit".AboutMe("Lorem ipsum dolor sit amet, consectetur adipisicing elit.");
            //Calling an extension method, passing value to it and getting value from it
            string information = "Creta".Car(104);
            Console.WriteLine(information);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SayHello();
            string name = Request.GetAString("Enter your name");
            UserMessage.ApplicationStartMessage(name);
            double x = Request.GetADouble("Enter your first number");
            double y = Request.GetADouble("Enter your second number");
            double result = CalculateData.Add(x, y);
            UserMessage.PrintResult($"The sum of {x} and {y} is {result}");
            Console.ReadLine();
        }
        private static void SayHello()
        {
            Console.WriteLine("Hello");
        }

        
    }
}

//Static class cannot contain non static method
//data stored in static will remain in the life time of the application
//connection string, key regarding who has logged in
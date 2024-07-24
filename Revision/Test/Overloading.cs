using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class Overloading
    {
        public void SayHello()
        {
            System.Console.WriteLine("Hello");
        }
        public void SayHello(string name)
        {
            System.Console.WriteLine($"Hello, {name}.");
        }

        public void SayHello(string name, string department)
        {
            System.Console.WriteLine($"Hello, {name}, your work is in {department}.");
        }

        public void MainFunction()
        {
            SayHello();
            SayHello("Ram");
            SayHello("Ram", "Account");
        }
    }
}
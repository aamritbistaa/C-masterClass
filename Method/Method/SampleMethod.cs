using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    public static class SampleMethod
    {
        public static void SayHi()
        {
            Console.WriteLine("Hi");
        }
        public static void SayHi(string name)
        {
            Console.WriteLine($"Hi {name}");
        }
        public static void SayGoodBye()
        {
            Console.WriteLine("Great Day!");
        }

        //tuple
        public static (string firstName,string lastName) GetFullName()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();

            return (firstName,lastName);    
        }

        
    }
}

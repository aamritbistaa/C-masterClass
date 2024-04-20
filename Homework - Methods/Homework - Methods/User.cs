using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Methods
{
    public class User
    {
        private static string name;
        public static void AskName()
        {
            Console.WriteLine("Enter your Name");
            name = Console.ReadLine();

        }
        public static void DisplayName()
        {
            Console.WriteLine($"Hello, {name}");
        }
    }
}

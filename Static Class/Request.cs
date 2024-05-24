using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class
{
    public static class Request
    {
        public static double GetADouble(string message)
        {
            Console.WriteLine(message);
            string numberText = Console.ReadLine();
            double output;
            bool isDouble = double.TryParse(numberText, out output);
            while (!isDouble)
            {
                Console.WriteLine("Invalid number, Please try again!");
                Console.WriteLine(message);
                numberText = Console.ReadLine();
                isDouble = double.TryParse(numberText, out output);
            }

            return output;
        }

        public static string GetAString(string message)
        {
            Console.WriteLine(message);
            string output = Console.ReadLine();
            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Class
{
    public static class UserMessage
    {
        public static void ApplicationStartMessage(string name)
        {
            Console.Clear();
            int hourOfDay = DateTime.Now.Hour;
            if (hourOfDay < 12)
            {
                Console.WriteLine($"Good Morning, {name}");
            }
            else if (hourOfDay < 19) {
                Console.WriteLine($"Good Afternoon, {name}");
            }
            else
            {
                Console.WriteLine($"Good Evening, {name}");
            }
        }

        public static void PrintResult(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine("thank you for using");
        }
    }
}

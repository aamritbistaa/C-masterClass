using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_BreakPoints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunsALot();

            Console.ReadLine();
        }
        public static void RunsALot()
        {
            long total = 0;
            int test = 0;
            for (int i=-1000; i<=1000; i++) { 
                total = total + i;
                try
                {
                    test = 5 / i;
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception while calculating test");
                }
            }
            Console.WriteLine($"The total is {total}");
        }
    }
}
//In breakpoints, we can right click and furthur add conditions and action.
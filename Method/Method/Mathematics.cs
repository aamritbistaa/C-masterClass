using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    internal class Mathematics
    {
        public static void Add(int a, int b)
        {
            Console.WriteLine($"{a+ b}");
        }
        public static void Difference(int a, int b)
        {
            if (a> b)
            {
                Console.WriteLine($"{a- b}");
            }
            else
            {
                Console.WriteLine($"{b - a}");
            }
        }
        public static double SumOfArray(double[] values)
        {
            double res=0;
            foreach (var item in values)
            {
                res+= item;
            }
            return res;
        }
    }
}

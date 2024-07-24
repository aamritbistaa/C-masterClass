using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class ValueAndReferenceDataType
    {
        public void IncreaseByValue(int number)
        {
            number++;
            Console.WriteLine($"Number in the function is {number}");
        }
        public void IncreaseByReference(ref int number)
        {
            number++;
            Console.WriteLine($"Number in the function is {number}");
        }
        public static void ChangeReferenceType(ref string name)
        {
            name = "Steve";
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class BoxingUnboxing
    {
        public void MainFunction()
        {
            //Boxing -> creating a list of type object and adding integer to this
            // wrapping integer into object type
            List<object> mixedList = new List<object>();

            mixedList.Add("First Group:");

            for (int j = 1; j < 5; j++)
            {
                mixedList.Add(j);
            }

            foreach (var item in mixedList)
            {
                Console.WriteLine(item);
            }
           

            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                //Unboxing -> extracting data type (integer) from the item of the list
                sum += (int)mixedList[j] * (int)mixedList[j];
            }
            Console.WriteLine($"Sum of square {sum}");
        }
    }
}

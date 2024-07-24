using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class ControlFlow
    {
        public void GoToFunction()
        {
            int num = 20;


            if (num % 2 == 0)
            {
                goto Even;
            }
            else
            {
                goto Odd;
            }

        Even:
            Console.WriteLine("The number is even");
            //this return returns to calling point of this function
            return;

        Odd:
            Console.WriteLine("The number is odd");
        }

        public void BreakImplementation()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"{i}, {j}");
                    if (i == j) continue;
                    //if i and j are equal bottom wont be executed
                    // the loop will run for full duration
                    if (i == j)
                    {
                        Console.WriteLine("i and j are equal, skipping to next value of j");
                        break;
                    }
                }
            }
        }
    }
}
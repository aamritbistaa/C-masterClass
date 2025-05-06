using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handling_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] age=new int[] { 1, 2,3,4,5 };
            //for (int i = 0; i < age.Length; i++)
                for (int i = 0;i<=age.Length; i++)  //Index Out of Range Error 
            {
                try
                {
                    Console.WriteLine(age[i]);

                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    throw new Exception("Error occured while doing operation in application", ex);
                }
            }

            Console.ReadLine();
        }
    }
}

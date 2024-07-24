using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class ReadOnlyAndStatic
    {
       
        
        public class ImplementationClass
        {
            public readonly string name = "Default";

            public ImplementationClass()
            {
                Console.WriteLine($"Object Created {name}");
            }
            public ImplementationClass(string name)
            {
                this.name = name;
            }
        }




        public void MainFunction()
        {
            ImplementationClass obj = new ImplementationClass();
            //Throws error, readonly variable can only be accessed via construnctor (during object creation)
            //obj.name = "Ram";
            ImplementationClass obj1= new ImplementationClass("Hari");


        }
    }
}

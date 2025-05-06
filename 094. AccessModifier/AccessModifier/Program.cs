using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLibrary;

namespace AccessModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            //--------private property--------
            //person.FirstName = "Amrit Bista";
            person.SSN = "1234-21-1213";
                person.SayHello();

            //-------internal Class--------
            //DataAccess data = new DataAccess();
            //data.GetConnectionString();

            Console.WriteLine(person.SSN);
            Console.ReadLine();
        }
    }
}
//private protected are available to the class and the children of class
//protected internal are available to the project or assembly and also the child of class in the assembly
//internal are available to the project or assembly they are created on
//private are limited to the class
//protected are available to derived class too
//public can be used from anywhere

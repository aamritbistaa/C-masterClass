using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLibrary;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel();
            person.Name = "Ramesh";
            Console.WriteLine(
            Calculation.Add(10, 20)
                );

            Console.ReadLine(); 
        }

    }
}
//When projects are created, the refrenece should be added from the project that need to access class library

//When class library are built, they are converted to dll file
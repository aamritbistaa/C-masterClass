using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel("bista");
            person.FirstName = "amrit";
            //person.LastName = "bista";

            person.Age = 12;
            person.SSN = "123-45-6789";
            //Console.WriteLine(person.FirstName);
            Console.WriteLine(person.FullName);
            Console.WriteLine(person.SSN);


            PersonModel person2 = new PersonModel();
            person2.FirstName = "Lawaris Ram";
            person2.Age = 48;
            person2.SSN = "123-45-9123";
            Console.WriteLine(person2.FullName);
            Console.WriteLine(person2.SSN);

            Console.ReadLine();
        }
    }
}

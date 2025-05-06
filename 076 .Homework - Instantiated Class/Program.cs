//Create a Console Application that has a Person Class and an Address Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Homework___Instantiated_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            
            Console.WriteLine("Enter y to continue");
            string choice = Console.ReadLine();
            while (choice.ToLower()=="y")
            {
                Console.WriteLine("Enter First Name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter City Name");
                string city = Console.ReadLine();
                Console.WriteLine("Enter District Name");
                string district = Console.ReadLine();
                Console.WriteLine("Enter Country Name");
                string country = Console.ReadLine();
                people.Add(new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address= new Address { City = city, Country = country, District = district }
                }) ;

                Console.WriteLine("Enter y to continue");
                choice = Console.ReadLine();
            }
            if (people.Count > 1)
            {
                foreach (var item in people)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} lives in {item.Address.City},{item.Address.Country},{item.Address.District}");
                }
            }

            Console.ReadLine();
        }
    }
}

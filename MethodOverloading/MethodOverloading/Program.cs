using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    //Here we have overloaded contructor
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonModel();
            person.Name = "Amrit Bista";
            person.Age = 23;
            person.Email = "aamritbsitaa@gmail.com";

            var person2 = new PersonModel("Amritbista","email",23);
            Console.WriteLine(person2.Email);
            person2.GenerateEmail(true);
            Console.WriteLine(person2.Email);

            Console.ReadLine();
        }
    }
    class PersonModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public PersonModel() { }
        public PersonModel(string name, string email,int age) 
        {
            Age=age;
            Name=name;
            Email=email;
        }

        public void GenerateEmail()
        {
            Email = $"{Name}@email.com";
        }

        public void GenerateEmail(string email) {
        Email = email ;
        }

        public void GenerateEmail(bool hasYearOfBorn)
        {
            if(hasYearOfBorn)
            {
                var currentDate = DateTime.Now;
                var currentYear = currentDate.Year - Age;

                Email = $"{Name}{currentYear.ToString().Substring(2)}@email.com";
            }
            
        }


    }
}

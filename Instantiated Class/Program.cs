using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instantiated_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            PersonModel person = new PersonModel();
            person.firstName = "amrit";
            person.lastName = "bista";
            person.emailAddress = "aamritbistaa@gmail.com";

            PersonModel person2 = new PersonModel();
            person2.firstName = "mrit";
            person2.lastName = "ista";
            person2.emailAddress = "mritistaa@gmail.com";
            */

            /*
            //Creating a list
            List<PersonModel> People = new List<PersonModel>();

            //adding item to the list
            People.Add(new PersonModel { firstName = "Amrit" });

            //creating a variable that can store the information
            PersonModel person = new PersonModel();
            
            person.firstName = "first person";
            People.Add(person);
            
            //using the same variable to store other information and then use it
            //firstly we created new instance of it so that it does not over write
            person = new PersonModel();
            person.firstName = "second person";
            People.Add(person);
            
            foreach (var item in People)
            {
                Console.WriteLine(item.firstName);
            }
            */

            List<PersonModel> people = new List<PersonModel>();
            string firstName = "";
            
            do
            {
                Console.WriteLine("Enter first name or exit to quit");
                firstName = Console.ReadLine();
                Console.WriteLine("Enter last name ");
                string lastName = Console.ReadLine();
                if (firstName.ToLower() != "exit")
                {
                    //PersonModel person = new PersonModel();
                    //person.FirstName = firstName;
                    //people.Add(person);

                    people.Add(new PersonModel { FirstName = firstName, LastName=lastName });

                }

            } while (firstName.ToLower() != "exit");
            Console.Clear();
            Console.WriteLine("Displaying first names ");
            foreach (var item in people)
            {
                //ProcessPerson ob = new ProcessPerson();
                //ob.GreetPerson(item);


                ProcessPerson.GreetPerson(item);
                //Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.ReadKey();
        }
    }
}
//Instantiated Class store data
//Static Class are used for stateless processing
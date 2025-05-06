using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instantiated_Class
{
    public  class ProcessPerson
    {
        public static void GreetPerson(PersonModel person)
        {
            Console.WriteLine($"Hello {person.FirstName} {person.LastName}");
            person.HasBeenGreeted = true;
        }
    }
}

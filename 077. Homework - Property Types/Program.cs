using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Create a class that has properties for street address, city,state, and zipcode.
//Then add a FullAddress property that is read-only
namespace Homework___Property_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Address> addresses = new List<Address>();
            addresses.Add(
                new Address { City = "Kathmandu", State = "Bagmati", ZipCode=6032, StreetAddress="Mandikatar" }
                );
            addresses.Add(
                new Address { City = "Kathmandu", State = "Bagmati", ZipCode = 6032, StreetAddress = "Chabahil" }
                );

            foreach ( Address address in addresses )
            {
                Console.WriteLine(address.FullAddress);
            }
            Console.ReadLine();
        }
    }
}

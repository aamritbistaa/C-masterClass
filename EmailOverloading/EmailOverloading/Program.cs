using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p =new Person();
            p.FirstName = "ALSKDAS";
            p.LastName = "ASD";
            p.GenerateEmail();
            Console.WriteLine(p.Email);
            p.GenerateEmail(true);
            Console.WriteLine(p.Email);
            p.GenerateEmail("bista");
            Console.WriteLine(p.Email);
            p.GenerateEmail("bista", true);
            Console.WriteLine(p.Email);
            Console.ReadLine();

        }
    }
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void GenerateEmail()
        {
            //Email = $"{FirstName}{LastName}@email.com";
            GenerateEmail("email", false);
        }

        public void GenerateEmail(string domain)
        {
            //Email = $"{FirstName}{LastName}@{domain}.com";
            GenerateEmail(domain, false);

        }
        public void GenerateEmail(bool firstInitialMethod)
        {
            //if(firstInitialMethod)
            //{
            //    Email = $"{FirstName.Substring(0,1)}{LastName}@email.com";
            //}
            //else
            //{
            //    Email = $"{FirstName}{LastName}@email.com";
            //}
            GenerateEmail("email", firstInitialMethod);
        }

        public void GenerateEmail(string domain, bool firstInitialMethod)
        {
            if (firstInitialMethod)
            {
                Email = $"{FirstName.Substring(0, 1)}{LastName}@email.com";
            }
            else
            {
                Email = $"{FirstName}{LastName}@{domain}.com";
            }
        }
    }

}

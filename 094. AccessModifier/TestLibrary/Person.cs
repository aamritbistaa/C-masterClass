using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class Person
    {
        protected string formerLastName = "";
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private string _ssn;

        public string SSN
        {
            get { return $"****-**-{_ssn.Substring(_ssn.Length-4)}"; }
            set { _ssn = value; }
        }
        public void ChangeLastName(string newLastName)
        {
            formerLastName=LastName;
            LastName = newLastName;
        }

        public void SayHello()
        {
            Console.WriteLine($"Hello {FirstName}");
        }

        public void SavePerson()
        {
            DataAccess data = new DataAccess();
            string conn = data.GetConnectionString();
            //save the user
        }
    }
}

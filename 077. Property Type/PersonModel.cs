using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Type
{
    public class PersonModel
    {
        public string FirstName { private get; set; }
        public string LastName { get;private set; }
        //propfull
        private string _password;

        public string Password
        {
            set { _password = value; }
        }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        //public int Age { get; set; }
        private int _age;
        public int Age
        {
            get { return _age; }
            set { 
                if(value >= 0 && value<126)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "Age needs to be in a valid range");
                }   
            }
        }

        //public string SSN { get; set; } //Social Security Number 123-45-6789
        private string _ssn;

        public string SSN
        {
            get { 
                //123-45-6789
                string output = "***-**-"+_ssn.Substring(_ssn.Length-4);
                return output; }
            set { _ssn = value; }
        }

        public PersonModel()
        {

        }
        public PersonModel(string lastName)
        {
            LastName = lastName;
        }


    }
}

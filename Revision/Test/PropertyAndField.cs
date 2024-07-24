using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class PropertyAndField
    {
        public class EmployeeModel
        {
            //field
            public Guid Id = Guid.NewGuid();
            //property
            public string Name { get; set; }
            private string _citizenshipId;
            public string CitizenshipId
            {
                get { return _citizenshipId; }
                set { _citizenshipId = value; }
            }

            public int Age { get; set; }
        }

        public static void PropertyAndFieldMainFunction()
        {

            List<EmployeeModel> employees = new();
            bool hasMore = true;


            do
            {
                Console.WriteLine("Enter Name");
                string name = string.Empty;
                do
                {
                    name = Console.ReadLine();

                } while (name.Trim() == "");

                Console.WriteLine("Enter CitizenshipId");
                string citizenshipId = string.Empty;
                do
                {
                    citizenshipId = Console.ReadLine();

                } while (citizenshipId.Trim() == "");

                Console.WriteLine("Enter Age");
                int age;
                bool isValidAge = false;

                do
                {
                    string ageText = Console.ReadLine();
                    isValidAge = int.TryParse(ageText, out age);

                } while (!isValidAge);



                employees.Add(new EmployeeModel { CitizenshipId = citizenshipId, Name = name, Age = age });

                Console.WriteLine("Do you want to stop adding item, press y");
                string key = Console.ReadLine();

                if (key == "y" || key == "Y")
                {
                    hasMore = false;
                }

            } while (hasMore);

            foreach (EmployeeModel employee in employees)
            {
                Console.WriteLine($"{employee.Id}, {employee.Name}, {employee.CitizenshipId}, {employee.Age}");
            }
        }
    }
}
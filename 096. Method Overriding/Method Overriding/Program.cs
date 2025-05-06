using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Overriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel {FirstName="amrit",LastName="Bista",Email="aamritbistaa@gmail.com" };

            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.ToString());

            EmployeeModel employee = new EmployeeModel
            {
                Email = "emp@asd.com",
                FirstName = "asd",
                LastName = "asd",
                Designation = "Fulltime",
                HourlyRate = 10
            };
            employee.GetPayCheckAmout(5);

            CommissionEmployeeModel employee2 = new CommissionEmployeeModel
            {
                Email = "emp@asd.com",
                FirstName = "asd",
                LastName = "asd",
                Designation = "Commisioned employee",
                HourlyRate = 10,
                CommissionAmount = 10
            };
            employee2.GetPayCheckAmout(5);
            Console.ReadLine();
        }
    }
    public class CommissionEmployeeModel : EmployeeModel
    {
        public decimal CommissionAmount { get; set; }
        public override decimal GetPayCheckAmout(int hourWorked)
        {
           return base.GetPayCheckAmout(hourWorked)+CommissionAmount;
        }
    }
    public class EmployeeModel : PersonModel
    {
        public string Designation { get; set; }
        public decimal HourlyRate { get; set; }
        public virtual decimal GetPayCheckAmout(int hourWorked)
        {
            return HourlyRate* hourWorked;
        }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //without overriding this method, we were getting the namespace.classname
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

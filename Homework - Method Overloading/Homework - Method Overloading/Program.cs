using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Method_Overloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeModel employee = new EmployeeModel();
            Console.WriteLine(employee.Role);
            EmployeeModel employee2 = new EmployeeModel ("Ram",20 );
            Console.WriteLine(employee2.Role);
            EmployeeModel employee3 = new EmployeeModel("Ram", 20, (EmployeeRole)2);
            Console.WriteLine(employee3.Role);
            Console.ReadLine();
        }
    }

    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeRole Role { get; set; }
        public EmployeeModel() {
            Role = 0;
        }
        public EmployeeModel(string name, int id, EmployeeRole role)
        {
            Name = name;
            Id = id;
            Role = role;
        }
        public EmployeeModel(string name, int id)
        {
            Name = name;
            Id = id;
            Role = 0;
        }
    }
    public enum EmployeeRole
    {
        OfficeWorker,
        CEO,
        CTO,
        Manager
    }
}

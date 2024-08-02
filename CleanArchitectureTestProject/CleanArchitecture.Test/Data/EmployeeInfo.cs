using CleanArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.Data
{
    public class EmployeeInfo
    {
        public static void Initialize() {
        
        EmployeeList = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                IsDeleted = false,
                Position = "Junior",
                Salary =90123,
                DepartmentId =100,
                UserId =101
            },
            new Employee
            {
                Id = 2,
                IsDeleted = false,
                Position = "Junior",
                Salary =90123,
                DepartmentId =101,
                UserId =102
            }
        };

        }
        public static List<Employee> EmployeeList { get; set; } 
    }
}

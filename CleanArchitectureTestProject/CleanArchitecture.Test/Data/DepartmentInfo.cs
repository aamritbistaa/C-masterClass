using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.Data
{
    public class DepartmentInfo
    {
        public static void Init()
        {
            //Departments = new Department()
            //{
            //    Id = 3,
            //    IsDeleted = false,
            //    Name = "IT"
            //};
            DepartmentList = new List<Department>()
            {
                new Department()
                {
                    Id = 1,
                    IsDeleted = false,
                    Name = "IT"
                },
                    new Department()
                {
                    Id = 2,
                    IsDeleted = false,
                    Name = "IT"
                }
            };
        }
        //public static Department Departments { get; set; }
        public static List<Department> DepartmentList { get; set; }
    }
}

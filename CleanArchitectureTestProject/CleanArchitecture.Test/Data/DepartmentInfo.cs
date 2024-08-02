using CleanArchitecture.Application.DTO.Response;
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

            DepartmentResponseList = new List<DepartmentResponse>()
            {
                new DepartmentResponse()
                {
                    Id = 1,
                    IsDeleted = false,
                    Name = "IT"
                },
                new DepartmentResponse()
                {
                    Id = 2,
                    IsDeleted = false,
                    Name = "IT"
                }
            };

        }
        public static List<Department> DepartmentList { get; set; }
        public static List<DepartmentResponse> DepartmentResponseList { get; set; }


    }
}

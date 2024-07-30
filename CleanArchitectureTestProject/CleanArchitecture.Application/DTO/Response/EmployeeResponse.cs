using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTO.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public int? DepartmentId { get; set; }
        public bool IsDelted { get; set; }
    }
}

using CleanArchitecture.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTO.Response
{
    public class EmployeeResponse
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DateOfBirth { get; set; }
        public double? Salary { get; set; }
        public string? Position { get; set; }
        public string? Country { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? DepartmentName { get; set; }
        public string? UniqueId { get; set; }
        public GenderEnum? Gender { get; set; }

    }
}

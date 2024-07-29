using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTO.Request
{
    public class CreateEmployeeRequest
    {
        public int? UserId { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string Position { get; set; }
        public int? DepartmentId { get; set; }

    }
    public class UpdateEmployeeRequest
    {
        [Required]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public int? DepartmentId { get; set; }
    }
}

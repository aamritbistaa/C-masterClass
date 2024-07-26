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
        public string Name { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}

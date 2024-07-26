using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTO.Request
{
    public class CreateEmployeeRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
    }
    public class UpdateEmployeeRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
    }
}

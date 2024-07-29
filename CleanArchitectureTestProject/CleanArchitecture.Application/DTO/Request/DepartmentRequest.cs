using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTO.Request
{
    public class CreateDepartmentRequest
    {
        public string Name { get; set; }
    }
    public class UpdateDepartmentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

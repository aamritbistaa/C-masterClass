using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper
{
    public class DepartmentMapper
    {
        public static Department CreateDepartmentRequestToDepartmentMapper(CreateDepartmentRequest request)
        {
            return new Department
            {
                Name = request.Name,
            };
        }
    }
}

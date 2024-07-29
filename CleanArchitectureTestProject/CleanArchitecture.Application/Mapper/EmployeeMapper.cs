using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper
{
    public class EmployeeMapper
    {
        public static Employee CreateEmployeeRequestToEmployeeMapper(CreateEmployeeRequest request)
        {
            return new Employee
            {
                UserId = request?.UserId,
                Position = request.Position,
                Salary = request.Salary,
                DepartmentId = request?.DepartmentId,
            };
        }
    }
}

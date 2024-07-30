using AutoMapper;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<CreateDepartmentRequest, Department>();
            CreateMap<Department, DepartmentResponse>();
            CreateMap<CreateAddressRequest,Address>();
            CreateMap<Address, AddressResponse>();
            CreateMap<CreateEmployeeRequest,Employee>();
            CreateMap<Employee, EmployeeResponse>();
        }
    }
}

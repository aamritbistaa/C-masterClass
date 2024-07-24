using EmployeeMS.Dto.Response;
using EmployeeMS.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeMS.Mapper
{
    public static class Mappers
    {
        public static AddressResponse AddressToAddressResponseMapper(Address req)
        {
            return new AddressResponse()
            {
                Id = req.Id,
                City = req.City,
                Country = req.Country,
                IsDeleted = req.IsDeleted
            };
        }
        public static AttendanceResponse AttendanceToAttendanceResponseMapper(Attendance req)
        {
            return new AttendanceResponse()
            {
                Id = req.Id,
                EmployeeId = req.EmployeeId,
                Date = req.Date,
                InTime = req.InTime,
                IsDeleted = req.IsDeleted,
                OutTime = req?.OutTime,
            };
        }
        public static DepartmentResponse DepartmentToDepartementResponseMapper(Department req)
        {
            return new DepartmentResponse{
                Id = req.Id,
                Name = req.Name,
                IsDeleted = req.IsDeleted,
            };
        }

        public static EmployeeResponse EmployeeToEmployeeResponseMapper(Employee req)
        {
            return new EmployeeResponse()
            {
                Id = req.Id,
                Position = req.Position,
                Salary = req.Salary,
                IsDeleted = req.IsDeleted,
                DepartmentId = req?.DeptId,
                UserId = req?.UserId,
            };
        }

        public static UserResponse UserToUserResponseMapper(User req)
        {
            return new UserResponse
            {
                Id= req.Id,
                Name= req.Name,
                DateOfBirth = req.DateOfBirth,
                PhoneNumber = req.PhoneNumber,
                Gender = req.Gender,
                Email = req.Email,
                UniqueId = req.UniqueId,
                Password = req.Password,
                AddressId = req?.AddressId,
            };
        }
        
        
    }
}

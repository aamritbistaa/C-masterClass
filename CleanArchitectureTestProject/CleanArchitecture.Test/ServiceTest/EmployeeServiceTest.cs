using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Infrastructure.Repository;
using CleanArchitecture.Infrastructure.Service.Implementation;
using CleanArchitecture.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.ServiceTest
{
    public class EmployeeServiceTest : IClassFixture<DatabaseFixture>
    {
        [Fact]
        public async Task GetAllEmployee_ReturnsListOfEmployee()
        {
            //Arrange
            using (var _fixture = new DatabaseFixture())
            {
                var factory = new EmployeeServiceFactory(_fixture.mockDbContext);

                var expected = EmployeeInfo.EmployeeList;

                var service = new EmployeeService(factory);

                //Act
                var result = await service.GetAllEmployee();

                //Assert
                Assert.Equivalent(expected, result);
            }
        }
        [Fact]
        public async Task GetEmployeesById_ReturnsEmployee()
        {
            //Arrange
            int id = 10;
            using (var _fixture = new DatabaseFixture())
            {
                var _factory = new EmployeeServiceFactory(_fixture.mockDbContext);
                var service = new EmployeeService(_factory);

                var expected = await _fixture.mockDbContext.Departments.FindAsync(id);

                //Act
                var result = await service.GetEmployeeById(id);

                //Assert
                Assert.Equivalent(expected, result);
            }    
        }
        [Fact]
        public async Task AddEmployee_ReturnsModelWhenAdded()
        {
            //Arrange
            var itemToAdd = new Employee
            {
                Id = 120,
                IsDeleted = false,
                Position = "Junior",
                Salary = 90123,
                DepartmentId = 100,
                UserId = 101
            };
            var fixture = new DatabaseFixture();
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new EmployeeService(factory);
            
            //Act
            var result = await service.AddEmployee(itemToAdd);

            //Assert
            Assert.Equivalent(result, itemToAdd);
        }
        [Fact]
        public async Task UpdateEmployee_ReturnsTrueWhenUpdated()
        {
            //Arrange
            var fixture = new DatabaseFixture();
            var item = fixture.mockDbContext.Employees.Find(1);
            item.IsDeleted = true;
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new EmployeeService(factory);
            
            //Act
            var result = await service.UpdateEmployee(item);

            //Assert
            Assert.Equal(result, true);
        }
    }
}

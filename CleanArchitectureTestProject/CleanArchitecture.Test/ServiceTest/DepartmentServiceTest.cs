using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Infrastructure.Repository;
using CleanArchitecture.Infrastructure.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.ServiceTest
{
    public class DepartmentServiceTest : IClassFixture<DatabaseFixture>
    {
        [Fact]
        public async Task GetAllDepartment_ReturnsListOfDepartment()
        {
            //Arrange
            var fixture = new DatabaseFixture();
            var expected = fixture.mockDbContext.Departments.ToList();
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new DepartmentService(factory);
            //act
            var result = await service.GetAllDepartment();
            //assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task GetDepartmentById_ReturnsDepartmentModel()
        {
            //Arrange
            int id = 10;
            var fixture = new DatabaseFixture();
            var expected = fixture.mockDbContext.Departments.Find(id);
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new DepartmentService(factory);

            //Act
            var result = await service.GetDepartmentById(id);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task AddDepartment_ReturnsDepartment()
        {
            //Arrange
            var item = new Department
            {
                Id = 91,
                IsDeleted = false,
                Name = "Test",  
            };
            var expected = item;
            var fixture = new DatabaseFixture();
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new DepartmentService(factory);

            //Act
            var result = await service.AddDepartment(item);

            //Assert
            Assert.Equivalent(expected, result);    
        }
        [Fact]
        public async Task UpdateDepartment_ReturnsTrue()
        {
            //Arrange
            var fixture = new DatabaseFixture();    
            var itemFromDb =  fixture.mockDbContext.Departments.First();
            itemFromDb.IsDeleted = true;
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new DepartmentService(factory);
            //Act
            var result = await service.UpdateDepartment(itemFromDb);

            //Act
            Assert.Equal(result, true);
        }
    }
}

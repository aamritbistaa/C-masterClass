using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using CleanArchitecture.Infrastructure.Service.Implementation;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.Service
{
    public class DepartmentServiceTest
    {
        private readonly DepartmentService _sut;
        private readonly Mock<IEmployeeServiceFactory> _factory = new Mock<IEmployeeServiceFactory>();
        
        private readonly DatabaseFixture _fixture = new DatabaseFixture();

        public DepartmentServiceTest()
        {
            _sut = new DepartmentService(_factory.Object);
        }
        
        [Fact]
        public async Task GetAllDepartment_ReturnsDepartmentsAsync()
        {
            var expected = _fixture.mockDbContext.Departments.ToList();
            
            //Arrange

            _factory.Setup(x=>x.GetInstance<Department>().ListAsync()).ReturnsAsync(expected);

            //Act
            var result = await _sut.GetAllDepartment();
            
            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task GetDepartmentById_ReturnsDepartmentAsync()
        {
            //Arrange
            int id = 1;
            
            var expected = await _fixture.mockDbContext.Departments.FindAsync(id);
            _factory.Setup(x => x.GetInstance<Department>().FindAsync(id)).ReturnsAsync(expected);

            //Act
            var result = await _sut.GetDepartmentById(id);
            
            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task AddDepartment_ReturnsDepartmentAsync()
        {
            //Arrange
            var item = new Department
            {
                Id = 20,
                IsDeleted = false,
                Name = "test"
            };
            var expected = item;
            _factory.Setup(x => x.GetInstance<Department>().AddAsync(item)).ReturnsAsync(item);

            //Act
            var result = await _sut.AddDepartment(item);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task UpdateDepartment_ReturnsDepartmentAsync()
        {
            //Arrange
            var item = await _fixture.mockDbContext.Departments.FirstAsync();
            item.Id = 10;
            var expected = true;
            _factory.Setup(x => x.GetInstance<Department>().UpdateAsync(item)).ReturnsAsync(true);

            //Act
            var result = await _sut.UpdateDepartment(item);

            //Assert
            Assert.Equivalent(expected, result);
        }
    }
}

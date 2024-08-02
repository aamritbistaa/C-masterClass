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
    public class UserServiceTest:IClassFixture<DatabaseFixture>
    {
        [Fact]
        public async Task GetAllUser_ReturnsListOfUser()
        {
            var fixutre = new DatabaseFixture();

            var expected = UserInfo.UserList;
            var factory = new EmployeeServiceFactory(fixutre.mockDbContext);

            var service = new UserService(factory);

            //Act
            var result = await service.GetAllUser();

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task GetUserById_ReturnsUserModel()
        {
            //Arrange
            int id = 10;
            var fixture = new DatabaseFixture();
            var expected = fixture.mockDbContext.Users.Find(id);
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new UserService(factory);

            //Act
            var result = await service.GetUserById(id);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task AddUser_ReturnsUserModel()
        {
            //Arrange
            var item = new User
            {
                AddresId = 1,
                DateOfBirth = "2000-10-15",
                Email = "test@gmail.eep",
                IsDeleted = false,
                Name = "Test",
                PhoneNumber = "1234567890",
                UniqueId = "aljskdfhas-354",
                Gender = Domain.Enum.GenderEnum.Male,
                Id = 12,
            };
            var fixture = new DatabaseFixture();
            var expected = item;
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new UserService(factory);

            //Act
            var result = await service.AddUser(item);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task UpdateUser_ReturnsTrue()
        {
            //Arrange
            var item = new User
            {
                AddresId = 1,
                DateOfBirth = "2000-10-15",
                Email = "test@gmail.eep",
                IsDeleted = false,
                Name = "Test",
                PhoneNumber = "1234567890",
                UniqueId = "aljskdfhas-354",
                Gender = Domain.Enum.GenderEnum.Male,
                Id = 12,
            };
            var fixture = new DatabaseFixture();
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new UserService(factory);

            //Act
            await service.AddUser(item);
            item.AddresId = 20;
            var result = await service.UpdateUser(item);

            //Assert
            Assert.Equivalent(true, result);
        }
    }
}

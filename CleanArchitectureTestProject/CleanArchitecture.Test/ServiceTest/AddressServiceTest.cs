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
    public class AddressServiceTest : IClassFixture<DatabaseFixture>
    {
        [Fact]
        public async void GetAllAddress_ReturnsListOfAddress()
        {
            //Arrange
            var fixture = new DatabaseFixture();    
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new AddressService(factory);
            var expected = fixture.mockDbContext.Addressses.ToList();
            //Act
            var result = await service.GetAllAddress();

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void GetAddressById_ReturnsAddressModel()
        {
            //Arrange
            int id = 1;
            var fixture = new DatabaseFixture();
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new AddressService(factory);
            var expected = fixture.mockDbContext.Addressses.Find(id);

            //Act
            var result = await service.GetAddressById(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void AddAddess_ReturnsAddessModel()
        {
            //Arrange
            var fixture = new DatabaseFixture();
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new AddressService(factory);
            var itemToAdd = new Address
            {
                Id = 100,
                City = "test",
                Country = "test",
                IsDeleted = true,
                StreetAddress = "test"
            };
            var expected = itemToAdd;
            //Act
            var result = await service.AddAddress(itemToAdd);
            
            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void UpdateAddess_ReturnsAddessModel()
        {
            //Arrange
            var fixture = new DatabaseFixture();
            var factory = new EmployeeServiceFactory(fixture.mockDbContext);
            var service = new AddressService(factory);
            var itemToUpdate = fixture.mockDbContext.Addressses.First();
            itemToUpdate.IsDeleted = true;
            var expected = true;
            //Act
            var result = await service.UpdateAddress(itemToUpdate);

            //Assert
            Assert.Equivalent(expected, result);
        }
    }
}

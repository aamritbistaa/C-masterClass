using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Domain.Service.Interface;
using CleanArchitecture.Infrastructure.Service.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.Service
{
    public class AddressServiceTest
    {
        private readonly AddressService _sut;
        private readonly Mock<IEmployeeServiceFactory> _factoryMock = new Mock<IEmployeeServiceFactory>();
        public AddressServiceTest()
        {
            _sut = new AddressService(_factoryMock.Object);
        }
        private List<Address> addressList =
            new List<Address> {
                new Address {
                    City = "Kathmandu",
                    Country = "Nepal",
                    Id=1,
                    IsDeleted = false,
                },
                new Address {
                    City = "Baneshwor",
                    Country = "Nepal",
                    Id=1,
                    IsDeleted = false,
                }
            };

        [Fact]
        public async void GetAllAddress_ShouldReturnAllAddress()
        {
            //Arrange
            _factoryMock.Setup(x => x.GetInstance<Address>().ListAsync()).ReturnsAsync(addressList);

            //Act
            var result = await _sut.GetAllAddress();

            //Assert
            Assert.Equivalent(addressList, result);
        }
        [Fact]
        public async void GetAddressById_ShouldReturnAddress()
        {
            var id = 1;
            var expectedAddress = (from item in addressList
                           where item.Id == id
                           select item).First();
            //Arrange
            _factoryMock.Setup(x => x.GetInstance<Address>()
                                    .FindAsync(id))
                                    .ReturnsAsync(expectedAddress);

            //Act
            var result = await _sut.GetAddressById(id);

            //Assert
            Assert.Equivalent(expectedAddress, result);
        }
        [Fact]
        public async void AddAddress_ShouldReturnAddress()
        {
            //Arrange
            var expectedAddress = addressList[0];
            _factoryMock.Setup(x => x.GetInstance<Address>().AddAsync(expectedAddress)).ReturnsAsync(expectedAddress);

            //Act
            var result = await _sut.AddAddress(expectedAddress);

            //Assert
            Assert.Equivalent(expectedAddress, result);
        }
        [Fact]
        public async void UpdateAddress_ShouldReturnTrueonSuccess()
        {
            //Arrange
            var address = addressList[0];
            address.StreetAddress = "Sinamangal";
            _factoryMock.Setup(x => x.GetInstance<Address>().UpdateAsync(It.IsAny<Address>())).ReturnsAsync(true);

            //Act
            var result = await _sut.UpdateAddress(address);

            //Assert
            Assert.Equivalent(true, result);
        }
    }
}

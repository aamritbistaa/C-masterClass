using AutoMapper;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.Manager.Implementation;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using Moq;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Test.Manager
{

    public class AddressManagerTest
    {
        private readonly AddressManager _sut;
        private readonly Mock<IAddressService> _addressMock = new Mock<IAddressService>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IEmployeeServiceFactory> _factoryMock = new Mock<IEmployeeServiceFactory>();
        public AddressManagerTest()
        {
            _sut = new AddressManager(_addressMock.Object, _mapperMock.Object, _factoryMock.Object);
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
        public async void GetAllAddress_ShouldReturnListOfAddress_WhenAddressExist()
        {
            //Arrange
            _addressMock.Setup(x => x.GetAllAddress()).ReturnsAsync(addressList);

            //Act
            var result = await _sut.GetAllAddress();

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(result.Data, addressList);
            Assert.Equal(addressList.Count, result.Data.Count);
            Assert.Equal(result.Data[0].Id, addressList[0].Id);
            Assert.Equal(result.Data[0].City, addressList[0].City);
        }
        [Fact]
        public async void GetAddressById_ShouldReturnAddress_WhenAddressExistOrAddressModelIfNotFound()
        {
            //Arrange
            var id = 1;
            var address =
                (from item in addressList
                 where item.Id == id
                 select item).ToList().FirstOrDefault();
            if (address == null)
            {
                address = new Address();
            }
            _addressMock.Setup(x => x.GetAddressById(id)).ReturnsAsync(address);

            //Act
            var result = await _sut.GetAddressById(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(result.Data, address);
        }

        [Fact]
        public async void AddAddress_ShouldReturnAddress_WhenAddressIsAdded()
        {
            //Arrange
            var addressRequest = new CreateAddressRequest
            {

                City = "Kathmandu",
                Country = "Nepal",
                StreetAddress = "Mandikatar"
            };
            var address = new Address
            {
                Id =1,
                City = "Kathmandu",
                Country = "Nepal",
                StreetAddress = "Mandikatar",
                IsDeleted = false
            };
            var addressResponse = new Address
            {
                Id = 1,
                City = "Kathmandu",
                Country = "Nepal",
                StreetAddress = "Mandikatar",
                IsDeleted = false
            };
            _addressMock.Setup(x => x.AddAddress(It.IsAny<Address>())).ReturnsAsync(addressResponse);
            //Act

            var result = await _sut.AddAddress(addressRequest);

            //Assert
            Assert.Equivalent(result.Data, address);
        }
        [Fact]
        public async void UpdateAddress_ShouldReturnTrue_WhenAddressIsUpdate()
        {
            //Arrange
            var addressRequest = new UpdateAddressRequest
            {
                Id = 1,
                City = "Kathmandu",
                Country = "Nepal",
                StreetAddress = "Mandikatar"
            };
            var address = new Address
            {
                Id = 1,
                City = "Kathmandu",
                Country = "Nepal",
                StreetAddress = "Mandikatar"
            };

             var Expected_Result =  new ServiceResult<bool>
             {
                 Result = ResultStatus.Ok,
                 Message = "Address has been updated.",
                 Data = true
             };

            _addressMock.Setup(x => x.GetAddressById(address.Id)).ReturnsAsync(address);
            _addressMock.Setup(x => x.UpdateAddress(address)).ReturnsAsync(true);

            //Act
            var result = await _sut.UpdateAddress(addressRequest);

            //Assert
            //Assert.Equal(result, Expected_Result);
            Assert.Equivalent(result, Expected_Result);
        }
        [Fact]
        public async void DeleteAddress_ShouldReturnTrue_WhenAddressIsDeleted()
        {
            //Arrange
            var address = new Address
            {
                Id = 1,
                City = "Kathmandu",
                Country = "Nepal",
                StreetAddress = "Mandikatar"
            };
            var expectedResult = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "Address has been deleted",
                Data = false
            };
            _addressMock.Setup(x => x.GetAddressById(address.Id)).ReturnsAsync(address);
            _addressMock.Setup(x => x.UpdateAddress(address)).ReturnsAsync(true);

            //Act
            var result = await _sut.DeleteAddress(address.Id);

            //Assert
            Assert.Equivalent(expectedResult, result);
        }
    }
}
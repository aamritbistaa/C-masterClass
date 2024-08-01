using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Domain.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Test.Controller
{
    public class AddressControllerTest
    {
        private readonly AddressController _sut;
        private readonly Mock<IAddressManager> _manager = new Mock<IAddressManager>();
        public AddressControllerTest()
        {
            _sut = new AddressController(_manager.Object);
        }
        private List<AddressResponse> addressList =
                    new List<AddressResponse> {
                new AddressResponse {
                    City = "Kathmandu",
                    Country = "Nepal",
                    Id=1,
                    IsDeleted = false,
                },
                new AddressResponse {
                    City = "Baneshwor",
                    Country = "Nepal",
                    Id=1,
                    IsDeleted = false,
                }
            };
        [Fact]
        public async void GetAllAddress_ReturnsListOfAllAddress()
        {
            //Arrange
            var expectedResult = new ServiceResult<List<AddressResponse>>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying all Address",
                Data = addressList
            };
            _manager.Setup(x => x.GetAllAddress()).ReturnsAsync(expectedResult);

            //Act
            var result = await _sut.GetAllAddress();

            //Assert
            Assert.Equivalent(expectedResult, result);
        }

        [Fact]
        public async void GetddressById_ReturnsAddress()
        {
            //Arrange
            int id = addressList[0].Id;
            var expectedResult = new ServiceResult<AddressResponse>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying all Address",
                Data = addressList[0]
            };
            _manager.Setup(x => x.GetAddressById(id)).ReturnsAsync(expectedResult);

            //Act
            var result = await _sut.GetAddressById(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public async void AddAddress_ReturnsAddress()
        {
            //Arrange
            var address = new CreateAddressRequest
            {
                StreetAddress = "Kamal Binayak",
                City = "Bhaktapur",
                Country = "Nepal",
            };
            var expectedResult = new ServiceResult<AddressResponse>
            {
                Message = "Address has been added",
                Result = ResultStatus.Ok,
                Data = new AddressResponse
                {
                    Id = 10,
                    City = address.City,
                    Country = address.Country,
                    StreetAddress = address.StreetAddress,
                    IsDeleted = false,
                }
            };
            _manager.Setup(x => x.AddAddress(address)).ReturnsAsync(expectedResult);

            //Act
            var result = await _sut.AddAddress(address);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public async void UpdateAddress_ReturnsBoolean()
        {
            //Arrange
            var address = new UpdateAddressRequest
            {
                Id = 1,
                StreetAddress = "Kamal Binayak",
                City = "Bhaktapur",
                Country = "Nepal",
            };
            var expectedResult = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "Address has been updated.",
                Data = true
            };
            _manager.Setup(x => x.UpdateAddress(address)).ReturnsAsync(expectedResult);

            //Act
            var result = await _sut.UpdateAddress(address);

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(expectedResult, result);
        }
        [Fact]
        public async void DeleteAddress_ReturnsBoolean()
        {
            //Arrange
            int id = 1;
            var expectedResult = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "Address has been deleted",
                Data = true
            };
            _manager.Setup(x => x.DeleteAddress(id)).ReturnsAsync(expectedResult);

            //Act
            var result = await _sut.DeleteAddress(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(expectedResult, result);
        }
    }
}

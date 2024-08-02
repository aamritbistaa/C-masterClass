using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Test.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;
using static CleanArchitecture.Application.Common.Message;

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
        
        [Fact]
        public async void GetAllAddress_ReturnsListOfAllAddress()
        {
            AddressInfo.Initialize();
            var data = AddressInfo.AddressResponseList;
            //Arrange
            var expectedResult = new ServiceResult<List<AddressResponse>>
            {
                Result = ResultStatus.Ok,
                Message = AddressMessage.Displaying,
                Data = data
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
            AddressInfo.Initialize();

            var data = AddressInfo.AddressResponseList[0];

            //Arrange
            int id = data.Id;
            var expectedResult = new ServiceResult<AddressResponse>
            {
                Result = ResultStatus.Ok,
                Message = AddressMessage.Displaying,
                Data = data
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
            AddressInfo.Initialize();

            //Arrange
            var address = AddressInfo.CreateAddressRequest;

            var expectedResult = new ServiceResult<AddressResponse>
            {
                Result = ResultStatus.Ok,
                Message = AddressMessage.SuccessAdding,
                Data = AddressInfo.CreateAddressResponse
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
            AddressInfo.Initialize();

            //Arrange
            var address = AddressInfo.UpdateAddressRequest;
            var expectedResult = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = AddressMessage.SuccessUpdating,
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
                Message = AddressMessage.SuccessDeleting,
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

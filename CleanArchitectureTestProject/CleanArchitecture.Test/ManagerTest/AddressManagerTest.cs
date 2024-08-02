using AutoMapper;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Implementation;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using CleanArchitecture.Test.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;
using static CleanArchitecture.Application.Common.Message;

namespace CleanArchitecture.Test.ManagerTest
{
    public class AddressManagerTest
    {
        private readonly Mock<IAddressService> _addressServiceMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IEmployeeServiceFactory> _factoryMock = new();
        private readonly AddressManager _sut;
        public AddressManagerTest()
        {
            _sut = new(_addressServiceMock.Object,_mapperMock.Object,_factoryMock.Object);
        }
        [Fact]
        public async Task GetAllAddress_OnSuccess_RetunsAllAddress()
        {
            //Arrange
            AddressInfo.Initialize();
            _addressServiceMock.Setup(x => x.GetAllAddress()).ReturnsAsync(AddressInfo.AddressList);
            _mapperMock.Setup(x=>x.Map<AddressResponse>(It.IsAny<Address>())).Returns((Address x)=>AddressMapper.AddressToAddressResponseMapper(x));

            var expected = new ServiceResult<List<AddressResponse>>
            {
                Result = ResultStatus.Ok,
                Message = AddressMessage.Displaying,
                Data = AddressInfo.AddressResponseList
            };
            //Act
            var result = await _sut.GetAllAddress();
            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task GetAllAddress_OnNull_RetunsNull()
        {
            //Arrange
            //AddressInfo.Initialize();
            _addressServiceMock.Setup(x => x.GetAllAddress()).ReturnsAsync(new List<Address>());
            _mapperMock.Setup(x => x.Map<AddressResponse>(It.IsAny<Address>())).Returns((Address x) => AddressMapper.AddressToAddressResponseMapper(x));

            var expected = new ServiceResult<List<AddressResponse>>
            {
                Result = ResultStatus.Error,
                Message = AddressMessage.Empty,
                Data = new List<AddressResponse>()
            };
            //Act
            var result = await _sut.GetAllAddress();
            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task GetAddressById_OnSuccess_ReturnsModel()
        {
            //Arrange
            AddressInfo.Initialize();
            var data = AddressInfo.AddressList[0];
            _addressServiceMock.Setup(x=>x.GetAddressById(data.Id)).ReturnsAsync(data);
            var expected = new ServiceResult<AddressResponse>
            {
                Result = ResultStatus.Ok,
                Message = AddressMessage.Displaying,
                Data = AddressInfo.AddressResponseList[0]
            };
            //Act
            var result = await _sut.GetAddressById(data.Id);

            //Assert
            Assert.Equivalent(expected, result);
        }

    }
}

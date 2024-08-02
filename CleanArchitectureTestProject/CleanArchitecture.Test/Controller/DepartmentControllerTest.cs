using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Test.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArchitecture.Application.Common.CommonUtils;
using static CleanArchitecture.Application.Common.Message;

namespace CleanArchitecture.Test.Controller
{
    public class DepartmentControllerTest
    {
        private readonly DepartmentController _sut;
        private readonly Mock<IDepartmentManager> _manager = new();
        public DepartmentControllerTest()
        {
            _sut = new(_manager.Object);
        }

        DatabaseFixture _fixture = new DatabaseFixture();

        [Fact]
        public async void GetAllDepartment_ReturnsListOfDepartmentResponse()
        {
            var datas = DepartmentInfo.DepartmentResponseList;
            //Arrange
            var expected = new ServiceResult<List<DepartmentResponse>>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.Displaying,
                Data = datas
            };
            _manager.Setup(x => x.GetAllDepartment()).ReturnsAsync(expected);

            //Act
            var result = await _sut.GetAllDepartment();

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async void GetDepartmentById_ReturnsDepartmentResponse()
        {
            //Arrange
            
            var data = DepartmentInfo.DepartmentResponseList[0];
            var id = data.Id;

            var expected = new ServiceResult<DepartmentResponse>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.Displaying,
                Data = data
            };
            _manager.Setup(x => x.GetDepartmentById(id)).ReturnsAsync(expected);

            //Act
            var result = await _sut.GetDepartmentById(id);

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async void AddDepartment_ReturnsDepartmentResponse()
        {
            //Arrange
            int id = 1;
            var department = new CreateDepartmentRequest
            {
                Name = "IT"
            };
            var expected = new ServiceResult<DepartmentResponse>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.SuccessAdding,
                Data = DepartmentInfo.DepartmentResponseList[0]
            };
            _manager.Setup(x => x.AddDepartment(department)).ReturnsAsync(expected);

            //Act
            var result = await _sut.AddDepartment(department);

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void UpdateDepartment_ReturnsDepartmentResponse()
        {
            //Arrange
            int id = 1;
            var department = new UpdateDepartmentRequest
            {
                Id = 1,
                Name = "IT"
            };
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.SuccessUpdating,
                Data = true
            };
            _manager.Setup(x => x.UpdateDepartment(department)).ReturnsAsync(expected);

            //Act
            var result = await _sut.UpdateDepartment(department);

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void DeleteDepartment_ReturnsDepartmentResponse()
        {
            //Arrange
            int id = 1;

            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.SuccessDeleting,
                Data = true
            };
            _manager.Setup(x => x.DeleteDepartment(id)).ReturnsAsync(expected);

            //Act
            var result = await _sut.DeleteDepartment(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equivalent(expected, result);
        }
    }
}

using AutoMapper;
using CleanArchitecture.Application.DTO.Request;
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
    public class DepartmentManagerTest
    {
        private readonly Mock<IDepartmentService> _mockService = new();
        private readonly Mock<IMapper> _mockMapper = new();
        private readonly Mock<IEmployeeServiceFactory> _mockEmployeeFactory = new();
        private readonly DepartmentManager service;
        public DepartmentManagerTest()
        {
            service = new DepartmentManager(_mockService.Object, _mockMapper.Object, _mockEmployeeFactory.Object);
        }

        [Fact]
        public async Task GetAllDepartment_OnEmpty_ReturnNewListOfDepartment()
        {
            //Arrange
            var data = new List<Department>();
            var expected = new ServiceResult<List<DepartmentResponse>>
            {
                Result = ResultStatus.Error,
                Message = DepartmentMessage.Empty,
                Data = new List<DepartmentResponse>()
            };
            _mockService.Setup(x => x.GetAllDepartment()).ReturnsAsync(data);

            //Act
            var result = await service.GetAllDepartment();
            //Assert
            Assert.Equivalent(expected, result);

        }
        [Fact]
        public async Task GetAllDepartment_OnSuccess_ReturnListOfDepartment()
        {
            //Arrange
            DepartmentInfo.Init();
            var data = DepartmentInfo.DepartmentList;
            var expected = new ServiceResult<List<DepartmentResponse>>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.Displaying,
                Data = (data.Select(x => new DepartmentResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted
                })).ToList()
            };
            _mockService.Setup(x => x.GetAllDepartment()).ReturnsAsync(data);
            _mockMapper.Setup(x => x.Map<DepartmentResponse>(It.IsAny<Department>()))
                .Returns((Department d) => DepartmentMapper.DepartmentToDepartmentResponseMapper(d));
            //Act
            var result = await service.GetAllDepartment();
            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task GetDepartmentById_OnEmpty_ReturnsNewModel()
        {
            //Arrange
            var fixture = new DatabaseFixture();
            int id = 10;
            var item = await fixture.mockDbContext.Departments.FindAsync(id);

            var expected = new ServiceResult<DepartmentResponse>
            {
                Result = ResultStatus.Error,
                Message = DepartmentMessage.ItemNotFound,
                Data = new DepartmentResponse()
            };

            _mockService.Setup(x => x.GetDepartmentById(id)).ReturnsAsync(item);
            _mockMapper.Setup(x => x.Map<DepartmentResponse>(It.IsAny<Department>()))
                .Returns((Department d) => DepartmentMapper.DepartmentToDepartmentResponseMapper(d));
            //Act
            var result = await service.GetDepartmentById(id);

            //Assert
            Assert.Equivalent(expected,result);
        }
        [Fact]
        public async Task GetDepartmentById_OnSuccess_ReturnsModel()
        {
            //Arrange
            var fixture = new DatabaseFixture();
            int id = 1;
            var item = await fixture.mockDbContext.Departments.FindAsync(id);

            var expected = new ServiceResult<DepartmentResponse>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.Displaying,
                Data = DepartmentMapper.DepartmentToDepartmentResponseMapper(item)
            };
            
            _mockService.Setup(x => x.GetDepartmentById(id)).ReturnsAsync(item);
            _mockMapper.Setup(x => x.Map<DepartmentResponse>(It.IsAny<Department>()))
                .Returns((Department d) => DepartmentMapper.DepartmentToDepartmentResponseMapper(d));
            //Act
            var result = await service.GetDepartmentById(id);

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async Task AddDepartment_OnError_ReturnsNull()
        {
            //Arrange
             var expected = new ServiceResult<DepartmentResponse>
                    {
                        Result = ResultStatus.Error,
                        Message = DepartmentMessage.ErrorWhileAdding,
                        Data = null
                    };
            var item = new CreateDepartmentRequest
            {
                Name = "Helpers"
            };
            var department = DepartmentMapper.CreateDepartmentRequestToDepartmentMapper(item);
            _mockService.Setup(x => x.AddDepartment(department)).ReturnsAsync(department);

            _mockMapper.Setup(x => x.Map<Department>(It.IsAny<CreateDepartmentRequest>())).Returns((CreateDepartmentRequest req) => new Department
            {
                Id = 0,
                IsDeleted = false,
                Name = req.Name
            });
            //Act
            var result = await service.AddDepartment(item);
            
            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async Task AddDepartment_OnSuccess_ReturnsModel()
        {
            //Arrange
            DepartmentInfo.Init();
            var item = new CreateDepartmentRequest
            {
                Name = "Helpers"
            };
            var department = new Department
            {
                Id = 98,
                IsDeleted = false,
                Name = "Helpers"
            };
            var expected = new ServiceResult<DepartmentResponse>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.SuccessAdding,
                Data = DepartmentMapper.DepartmentToDepartmentResponseMapper(department)
            };

            _mockMapper.Setup(x => x.Map<DepartmentResponse>(It.IsAny<Department>())).Returns((Department x) => DepartmentMapper.DepartmentToDepartmentResponseMapper(x));
            _mockMapper.Setup(x => x.Map<Department>(It.IsAny<CreateDepartmentRequest>())).Returns((CreateDepartmentRequest req) => new Department
            {
                Id = 98,
                IsDeleted = false,
                Name = req.Name
            });


            _mockService.Setup(x => x.AddDepartment(It.IsAny<Department>())).ReturnsAsync(department);

            //Act
            var result = await service.AddDepartment(item);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void UpdateDepartment_OnError_DepartmentDoesnotExist()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Error,
                Message = DepartmentMessage.ItemNotFound,
                Data = false
            };

            _mockService.Setup(x => x.GetDepartmentById(It.IsAny<int>())).ReturnsAsync((Department)null);

            UpdateDepartmentRequest request = new UpdateDepartmentRequest
            {
                Id = 20,
                Name = "Core"
            };
            //Act
            var result = await service.UpdateDepartment(request);

            //Assert
            Assert.Equivalent(expected, result);

        }
        [Fact]
        public async void UpdateDepartment_OnError_WhileUpdatingDepartmentId()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Error,
                Message = DepartmentMessage.ErrorWhileUpdating,
                Data = false
            };
            DatabaseFixture fixture = new DatabaseFixture();
            var item = fixture.mockDbContext.Departments.First();

            var request = new UpdateDepartmentRequest
            {
                Id = item.Id,
                Name = "New Name",
            };
            _mockService.Setup(x => x.GetDepartmentById(It.IsAny<int>())).ReturnsAsync(item);
            _mockService.Setup(x => x.UpdateDepartment(It.IsAny<Department>())).ReturnsAsync(false);

            
            //Act
            var result = await service.UpdateDepartment(request);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void UpdateDepartment_OnSuccess_ReturnsTrue()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.SuccessUpdating,
                Data = true
            };
            DatabaseFixture fixture = new DatabaseFixture();
            var item = fixture.mockDbContext.Departments.First();

            var request = new UpdateDepartmentRequest
            {
                Id = item.Id,
                Name = "New Name",
            };
            

            _mockService.Setup(x => x.GetDepartmentById(It.IsAny<int>())).ReturnsAsync(item);
            _mockService.Setup(x => x.UpdateDepartment(It.IsAny<Department>())).ReturnsAsync(true);
            
            //Act
            var result = await service.UpdateDepartment(request);

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async void DeleteDepartment_OnError_DepartmentDoesnotExist()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Error,
                Message = DepartmentMessage.ItemNotFound,
                Data = false
            };

            _mockService.Setup(x => x.GetDepartmentById(It.IsAny<int>())).ReturnsAsync((Department)null);

            
            //Act
            var result = await service.DeleteDepartment(10);

            //Assert
            Assert.Equivalent(expected, result);

        }

        [Fact]
        public async void DeletingDepartment_OnError()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Error,
                Message = DepartmentMessage.ErrorWhileDeleting,
                Data = false
            };
            DatabaseFixture fixture = new DatabaseFixture();
            var item = fixture.mockDbContext.Departments.First();

            var request = new UpdateDepartmentRequest
            {
                Id = item.Id,
                Name = "New Name",
            };
            _mockService.Setup(x => x.GetDepartmentById(It.IsAny<int>())).ReturnsAsync(item);
            _mockService.Setup(x => x.UpdateDepartment(It.IsAny<Department>())).ReturnsAsync(false);

            //Act
            var result = await service.DeleteDepartment(10);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void DeleteDepartment_OnSuccess_ReturnsTrue()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = DepartmentMessage.SuccessDeleting,
                Data = true
            };
            DatabaseFixture fixture = new DatabaseFixture();
            var item = fixture.mockDbContext.Departments.First();
            int id = 19;

            _mockService.Setup(x => x.GetDepartmentById(id)).ReturnsAsync(item);
            _mockService.Setup(x => x.UpdateDepartment(It.IsAny<Department>())).ReturnsAsync(true);

            //Act
            var result = await service.DeleteDepartment(19);

            //Assert
            Assert.Equivalent(expected, result);
        }


    }
}

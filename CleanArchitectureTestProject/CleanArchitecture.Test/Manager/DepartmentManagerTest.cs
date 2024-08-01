using AutoMapper;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Implementation;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Moq;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Test.Manager
{
    public class DepartmentManagerTest
    {
        private readonly DepartmentManager _sut;
        private readonly Mock<IDepartmentService> _departmentMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IEmployeeServiceFactory> _factory = new();
        private readonly DatabaseFixture _testdb = new();
        public DepartmentManagerTest()
        {
            _sut = new DepartmentManager(_departmentMock.Object, _mapperMock.Object, _factory.Object);
        }
        [Fact]
        public async void GetAllDepartment_ReturnsDepartmentsResponses()
        {
            //Arrange
            var allDepartment = await _testdb.mockDbContext.Departments.ToListAsync();
            var allDepartmentResponse = (from item in allDepartment select DepartmentMapper.DepartmentToDepartmentResponseMapper(item)).ToList();

            _departmentMock.Setup(x => x.GetAllDepartment()).ReturnsAsync(allDepartment);
            _mapperMock.Setup(x => x.Map<DepartmentResponse>(It.IsAny<Department>()))
                        .Returns((Department d) => new DepartmentResponse
                        {
                            Name = d.Name,
                            Id = d.Id,
                            IsDeleted = d.IsDeleted
                        });

            var expected = new ServiceResult<List<DepartmentResponse>>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying department records.",
                Data = allDepartmentResponse
            };
            //Act
            var result = await _sut.GetAllDepartment();

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async void GetDepratmentById_ReturnsDepartmentResponse()
        {
            var id = 1;
            //Arrange
            var department = await _testdb.mockDbContext.Departments.FindAsync(id);

            var expected = new ServiceResult<DepartmentResponse>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying department record.",
                Data = DepartmentMapper.DepartmentToDepartmentResponseMapper(department)
            };
            _departmentMock.Setup(x => x.GetDepartmentById(id)).ReturnsAsync(department);
            _mapperMock.Setup(x => x.Map<DepartmentResponse>(department)).Returns((Department x) => new DepartmentResponse
            {
                Id = x.Id,
                Name = x.Name,
                IsDeleted = x.IsDeleted
            });

            //Act
            var result = await _sut.GetDepartmentById(id);

            //Assert
            Assert.Equivalent(expected, result);
        }
    }
}

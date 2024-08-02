using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.DTO.Request;
using CleanArchitecture.Application.DTO.Response;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Enum;
using CleanArchitecture.Test.Data;
using Moq;
using static CleanArchitecture.Application.Common.CommonUtils;

namespace CleanArchitecture.Test.Controller
{
    public class UserControllerTest
    {
        private readonly UserController _sut;
        private readonly Mock<IUserManager> _mockUserManager = new();
        DatabaseFixture _fixture = new();
        public UserControllerTest()
        {
            _sut = new(_mockUserManager.Object);
        }
        [Fact]
        public async void GetAllUser_OnSuccess_ReturnsServiceResultSuccess()
        {
            //Arrange
            var userResponses = UserInfo.userResponseList;
            var expected = new ServiceResult<List<UserResponse>>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying user table",
                Data = userResponses
            };
            _mockUserManager.Setup(x => x.GetAllUser()).ReturnsAsync(expected);

            //Act
            var result = await _sut.GetAllUser();

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async void GetAllUser_OnNull_ReturnsServiceResultError()
        {
            //Arrange
            var userResponses = UserInfo.userResponse;
            var expected = new ServiceResult<List<UserResponse>>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying user table",
                Data = new List<UserResponse>()
            };
            _mockUserManager.Setup(x => x.GetAllUser()).ReturnsAsync(expected);

            //Act
            var result = await _sut.GetAllUser();

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void GetUserById_OnSuccess_ReturnsServiceResultSuccess()
        {
            //Arrange
            var response = UserInfo.userResponse;
            int id = response.Id;

            var expected = new ServiceResult<UserResponse>
            {
                Result = ResultStatus.Ok,
                Message = "Displaying user table",
                Data = response
            };
            _mockUserManager.Setup(x => x.GetUserById(id)).ReturnsAsync(expected);

            //Act
            var result = await _sut.GetUserById(id);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void GetUserById_OnNull_ReturnsServiceResultNull()
        {
            //Arrange
            UserResponse response = null;
            int id = 10;
            var expected = new ServiceResult<UserResponse>
            {
                Result = ResultStatus.Error,
                Message = "User table is empty",
                Data = new UserResponse()
            };
            _mockUserManager.Setup(x => x.GetUserById(10)).ReturnsAsync(expected);

            //Act
            var result = await _sut.GetUserById(id);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void AddUser_OnRepeatedUser_ReturnnsError()
        {
            //Arrange
            CreateUserRequest request = new CreateUserRequest
            {
                Name = "User 1",
                AddresId = 10,
                Email = "test123@gmail.com",
                DateOfBirth = "2001-01-01",
                PhoneNumber = "+977-9856-23-1256",
                UniqueId = "012293aksdal-sd2",
                Gender = GenderEnum.Female,
            };
                
            var expected = new ServiceResult<UserResponse>
            {
                Result = ResultStatus.Error,
                Message = "User with specified email, phone or unique id is already present",
                Data = new UserResponse()
            };
            _mockUserManager.Setup(x => x.AddUser(request)).ReturnsAsync(expected);

            //Act
            var result = await _sut.AddUser(request);

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async void AddUser_OnNewUser_ReturnnsSuccess()
        {
            //Arrange
            CreateUserRequest request = new CreateUserRequest
            {
                Name = "User 1",
                AddresId = 10,
                Email = "test123@gmail.com",
                DateOfBirth = "2001-01-01",
                PhoneNumber = "+977-9856-23-1256",
                UniqueId = "012293aksdal-sd2",
                Gender = GenderEnum.Female,
            };

            var userRequest = UserMapper.CreateUserRequestToUser(request);
            var userResponse = UserMapper.UserToUserResponse(userRequest);
            var expected = new ServiceResult<UserResponse>
            {
                Result = ResultStatus.Ok,
                Message = "User has been added.",
                Data = userResponse
            };
            _mockUserManager.Setup(x => x.AddUser(request)).ReturnsAsync(expected);

            //Act
            var result = await _sut.AddUser(request);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void AddUser_ErrorOnAddingNewUser_ReturnsError()
        {
            //Arrange
            CreateUserRequest request = new CreateUserRequest
            {
                Name = "User 1",
                AddresId = 10,
                Email = "test123@gmail.com",
                DateOfBirth = "20-01-01",
                PhoneNumber = "+977-23-1256",
                UniqueId = "012293aksdal-sd2",
                Gender = GenderEnum.Female,
            };
             var expected = new ServiceResult<UserResponse>
            {
                Result = ResultStatus.Error,
                Message = "Unable to add user User",
                Data = new UserResponse()
            };
            _mockUserManager.Setup(x => x.AddUser(request)).ReturnsAsync(expected);

            //Act
            var result = await _sut.AddUser(request);

            //Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public async void UpdateUser_Error_WhileSearchingForUser()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Error,
                Message = "Unable to find User with the specified Id",
                Data = false
            };
            var request = new UpdateUserRequest
            {
                Id=1111,
                Name = "User 1",
                AddresId = 10,
                Email = "test123@gmail.com",
                DateOfBirth = "20-01-01",
                PhoneNumber = "+977-23-1256",
                UniqueId = "012293aksdal-sd2",
                Gender = GenderEnum.Female,
            };
            _mockUserManager.Setup(x => x.UpdateUser(request)).ReturnsAsync(expected);
            
            //Act
            var result = await _sut.UpdateUser(request);

            //Assert
            Assert.Equivalent(expected,result);
        }
        [Fact]
        public async void UpdateUser_Error_WhileUserWithSameDetailsExist()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Error,
                Message = "User with specified email, phone or unique id is already present",
                Data = false
            };
            var request = new UpdateUserRequest
            {
                Id = 1111,
                Name = "User 1",
                AddresId = 10,
                Email = "test123@gmail.com",
                DateOfBirth = "20-01-01",
                PhoneNumber = "+977-23-1256",
                UniqueId = "012293aksdal-sd2",
                Gender = GenderEnum.Female,
            };
            _mockUserManager.Setup(x => x.UpdateUser(request)).ReturnsAsync(expected);

            //Act
            var result = await _sut.UpdateUser(request);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void UpdateUser_Success_UserDetailsUpdatedSuccessfully()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "User has be updated",
                Data = true
            };
            var request = new UpdateUserRequest
            {
                Id = 1111,
                Name = "User 1",
                AddresId = 10,
                Email = "test123@gmail.com",
                DateOfBirth = "2009-01-01",
                PhoneNumber = "+977-9823-10-1256",
                UniqueId = "012293aksdal-sd2",
                Gender = GenderEnum.Female,
            };
            _mockUserManager.Setup(x => x.UpdateUser(request)).ReturnsAsync(expected);

            //Act
            var result = await _sut.UpdateUser(request);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void DeleteUser_OnError_UserDoesNotExistError()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Error,
                Message = "Unable to find User with the specified Id",
                Data = false
            };
            int id = 20;
            _mockUserManager.Setup(x => x.DeleteUser(id)).ReturnsAsync(expected);

            //Act
            var result = await _sut.DeleteUser(id);

            //Assert
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public async void DeleteUser_OnSuccess_UserDeletedSuccessfully()
        {
            //Arrange
            var expected = new ServiceResult<bool>
            {
                Result = ResultStatus.Ok,
                Message = "User has be deleted",
                Data = true
            };
            int id = 20;
            _mockUserManager.Setup(x => x.DeleteUser(id)).ReturnsAsync(expected);

            //Act
            var result = await _sut.DeleteUser(id);

            //Assert
            Assert.Equivalent(expected, result);
        }

    }
}

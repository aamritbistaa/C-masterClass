using CQRSApplication.Command.AuthUserCommand;
using CQRSApplication.Context;
using CQRSApplication.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace CQRSApplication.Test.UserControllersTest
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnToken_WhenCredentialsAreValid()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Login")
                .Options;

            using var dbContext = new CQRSDbContext(options);

            var userId = Guid.NewGuid();
            var userCredentials = new UserCredentials
            {
                Id = userId,
                Email = "valid@example.com",
                UserName = "validUser",
                Password = "validPassword",
                Role = RoleType.Customer
            };
            var user = new User
            {
                Id = userId,
                FirstName = "Yash",
                LastName = "Yadav",
                PhoneNumber = "1234567890",  // Required property
                Address = "123 Main St",     // Required property
                UserCredentialsId = userId
            };

            dbContext.UserCredentials.Add(userCredentials);
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(c => c["JWT:SecretKey"]).Returns("very_secret_key_12345678901234567890");
            configurationMock.Setup(c => c["JWT:Issuer"]).Returns("issuer");
            configurationMock.Setup(c => c["JWT:Audience"]).Returns("audience");

            var handler = new LoginUserCommandHandler(dbContext, configurationMock.Object);
            var command = new LoginUserCommand
            {
                Email = "valid@example.com",
                Password = "validPassword"
            };
            var cancellationToken = new CancellationToken();

            // Act
            var response = await handler.Handle(command, cancellationToken);

            // Assert
            Assert.NotNull(response.Token);
            Assert.Equal("validUser", response.UserName);
            Assert.Equal(user.Id, response.UserId);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenCredentialsAreInvalid()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Login_Invalid")
                .Options;

            using var dbContext = new CQRSDbContext(options);

            var configurationMock = new Mock<IConfiguration>();

            var handler = new LoginUserCommandHandler(dbContext, configurationMock.Object);
            var command = new LoginUserCommand
            {
                Email = "invalid@example.com",
                Password = "invalidPassword"
            };
            var cancellationToken = new CancellationToken();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, cancellationToken));
        }
    }
}

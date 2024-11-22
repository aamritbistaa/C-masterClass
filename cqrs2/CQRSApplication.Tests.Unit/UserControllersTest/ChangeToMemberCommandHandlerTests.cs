using CQRSApplication.Command.AuthUserCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CQRSApplication.Context;
using Moq;
using CQRSApplication.Model;

namespace CQRSApplication.Test.UserControllersTest
{
    public class ChangeToMemberCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldChangeUserRoleToCustomer_WhenUserIsVendor()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_ChangeToMember")
                .Options;

            using var dbContext = new CQRSDbContext(options);
            var mediatorMock = new Mock<IMediator>();

            var userId = Guid.NewGuid();
            var existingUser = new User
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
                Address = "123 Main St",
                UserCredentialsId = userId
            };
            var existingUserCredentials = new UserCredentials
            {
                Id = userId,
                Email = "john.doe@example.com",
                UserName = "john.doe",
                Password = "password123",
                Role = RoleType.Vendor
            };

            dbContext.Users.Add(existingUser);
            dbContext.UserCredentials.Add(existingUserCredentials);
            await dbContext.SaveChangesAsync();

            var changeToMemberCommand = new ChangeToMemberCommand { Id = userId };
            var handler = new ChangeToMemberCommandHandler(dbContext, mediatorMock.Object);
            var cancellationToken = new CancellationToken();

            // Act
            var result = await handler.Handle(changeToMemberCommand, cancellationToken);

            // Assert
            Assert.Equal(RoleType.Customer, existingUserCredentials.Role);
            Assert.Equal(existingUser, result);
        }
        [Fact]
        public async Task Handle_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_ChangeToMember")
                .Options;

            using var dbContext = new CQRSDbContext(options);
            var mediatorMock = new Mock<IMediator>();

            var changeToMemberCommand = new ChangeToMemberCommand { Id = Guid.NewGuid() };
            var handler = new ChangeToMemberCommandHandler(dbContext, mediatorMock.Object);
            var cancellationToken = new CancellationToken();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(changeToMemberCommand, cancellationToken));
        }
    }
}

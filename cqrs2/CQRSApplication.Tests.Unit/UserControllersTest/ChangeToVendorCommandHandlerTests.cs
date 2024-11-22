using CQRSApplication.Command.AuthUserCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CQRSApplication.Context;
using Moq;
using CQRSApplication.Model;

namespace CQRSApplication.Test.UserControllersTest
{
    public class ChangeToVendorCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldChangeUserRoleToVendor_WhenUserIsCustomer()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_ChangeToVendor")
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
                Role = RoleType.Customer
            };

            existingUser.shippingAddress = new ShippingAddress
            {
                Id = Guid.NewGuid(),
                StreetAddress = "456 Secondary St",
                City = "Secondary City",
                District = "Secondary District"
            };

            dbContext.Users.Add(existingUser);
            dbContext.UserCredentials.Add(existingUserCredentials);
            await dbContext.SaveChangesAsync();

            var changeToVendorCommand = new ChangeToVendorCommand { Id = userId };
            var handler = new ChangeToVendorCommandHandler(dbContext, mediatorMock.Object);
            var cancellationToken = new CancellationToken();

            // Act
            var result = await handler.Handle(changeToVendorCommand, cancellationToken);

            // Assert
            Assert.Equal(RoleType.Vendor, existingUserCredentials.Role);
            Assert.Equal(existingUser, result);
        }
        [Fact]
        public async Task Handle_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_ChangeToVendor")
                .Options;

            using var dbContext = new CQRSDbContext(options);
            var mediatorMock = new Mock<IMediator>();

            var changeToVendorCommand = new ChangeToVendorCommand { Id = Guid.NewGuid() };
            var handler = new ChangeToVendorCommandHandler(dbContext, mediatorMock.Object);
            var cancellationToken = new CancellationToken();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(changeToVendorCommand, cancellationToken));
        }
    }
}

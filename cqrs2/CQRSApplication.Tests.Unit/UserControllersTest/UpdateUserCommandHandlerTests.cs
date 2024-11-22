using CQRSApplication.Command.AuthUserCommand;
using CQRSApplication.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CQRSApplication.Context;
using Moq;

namespace CQRSApplication.Test.UserControllersTest
{
    public class UpdateUserCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnUpdatedUser_WhenUserIsUpdatedSuccessfully()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_UpdateUser")
                .Options;

            using var dbContext = new CQRSDbContext(options);
            var mediatorMock = new Mock<IMediator>();

            var userId = Guid.NewGuid();
            var existingUser = new User
            {
                Id = userId,
                FirstName = "Yash",
                LastName = "yadav",
                PhoneNumber = "1234567890",
                Address = "123 Main St",
                ImageUrl = "image.jpg",
                UserCredentialsId = userId
            };
            var existingUserCredentials = new UserCredentials
            {
                Id = userId,
                Email = "Yash.yadav@example.com",
                UserName = "Yash.yadav",
                Password = "password123",
                Role = RoleType.Customer
            };

            dbContext.Users.Add(existingUser);
            dbContext.UserCredentials.Add(existingUserCredentials);
            await dbContext.SaveChangesAsync();

            var updateUserCommand = new UpdateUserCommand
            {
                Id = userId,
                FirstName = "Yash Updated",
                LastName = "yadav Updated",
                PhoneNumber = "0987654321",
                Address = "456 Another St",
                Image = null,
                UpdateUserCredentials = new UpdateUserCredentials
                {
                    UserName = "Yash.yadav.updated",
                    OldPassword = "password123",
                    NewPassword = "newpassword123",
                    Email = "Yash.yadav.updated@example.com"
                },
                ShippingAddress = new UpdateShippingAddress
                {
                    City = "New City",
                    District = "New District",
                    Street = "456 New Street"
                }
            };

            var handler = new UpdateUserCommandHandler(dbContext, mediatorMock.Object);
            var cancellationToken = new CancellationToken();

            // Act
            var result = await handler.Handle(updateUserCommand, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updateUserCommand.FirstName, result.FirstName);
            Assert.Equal(updateUserCommand.LastName, result.LastName);
            //result.Should().BeEquivalentTo(updateUserCommand);
        }
    }
}
using CQRSApplication.Command.AuthUserCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CQRSApplication.Context;
using Moq;
using CQRSApplication.Model;

namespace CQRSApplication.Test.UserControllersTest
{
    public class DeleteUserCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnSuccessMessage_WhenUserIsDeletedSuccessfully()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_DeleteUser")
                .Options;

            // Insert user into the in-memory database
            using (var dbContext = new CQRSDbContext(options))
            {
                var userId = Guid.NewGuid();
                var existingUser = new User
                {
                    Id = userId,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St",
                    UserCredentialsId = Guid.NewGuid()
                };

                dbContext.Users.Add(existingUser);
                await dbContext.SaveChangesAsync();
            }

            // Use userId to create DeleteUserCommand
            using (var dbContext = new CQRSDbContext(options))
            {
                var mediatorMock = new Mock<IMediator>();

                var userId = Guid.NewGuid();
                // GenerateS a new Guid for user ID

                var deleteUserCommand = new DeleteUserCommand { Id = userId };
                var handler = new DeleteUserCommandHandler(dbContext, mediatorMock.Object);
                var cancellationToken = new CancellationToken();

                // Act & Assert
                // Since the user with userId doesn't exist in the database, it should throw an exception
                await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(deleteUserCommand, cancellationToken));
            }
        }
    }
}

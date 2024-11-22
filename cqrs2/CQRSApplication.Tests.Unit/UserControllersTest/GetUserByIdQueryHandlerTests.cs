using CQRSApplication.Query.UserQuery;
using Microsoft.EntityFrameworkCore;
using CQRSApplication.Context;
using CQRSApplication.Model;

namespace CQRSApplication.Test.UserControllersTest
{
    public class GetUserByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_GetUserById")
                .Options;

            Guid userId = Guid.NewGuid(); // GenerateS a new Guid for user ID

            using (var dbContext = new CQRSDbContext(options))
            {
                var existingUser = new User
                {
                    Id = userId,
                    FirstName = "Yash",
                    LastName = "Yadav",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St",
                    UserCredentialsId = Guid.NewGuid()
                    // Assuming UserCredentialsId is set
                };
                var usercred = new UserCredentials
                {
                    Id = existingUser.UserCredentialsId,
                    Role = RoleType.Customer,
                    UserName = "yash",
                    Email = "yash@yash.com",
                    Password = "string",
                    IsActive = false
                };
                dbContext.Add(usercred);
                dbContext.Users.Add(existingUser);
                await dbContext.SaveChangesAsync();
            }

            // Use userId to create GetUserByIdQuery
            using (var dbContext = new CQRSDbContext(options))
            {
                //var mediatorMock = new Mock<IMediator>();

                var getUserByIdQuery = new GetUserByIdQuery { Id = userId };
                var handler = new GetUserByIdQueryHandler(dbContext);
                var cancellationToken = new CancellationToken();

                // Act
                var result = await handler.Handle(getUserByIdQuery, cancellationToken);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Yash", result.FirstName);
                Assert.Equal("Yadav", result.LastName);
                // Add more assertions as needed
            }
        }
        [Fact]
        public async Task Handle_ShouldThrowException_WhenUserDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_GetUserById_Invalid")
                .Options;

            using var dbContext = new CQRSDbContext(options);
            var handler = new GetUserByIdQueryHandler(dbContext);
            var getUserByIdQuery = new GetUserByIdQuery { Id = Guid.NewGuid() };
            var cancellationToken = new CancellationToken();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(getUserByIdQuery, cancellationToken));
        }
    }
}

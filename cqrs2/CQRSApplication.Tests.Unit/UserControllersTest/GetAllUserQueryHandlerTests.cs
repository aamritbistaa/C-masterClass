using CQRSApplication.Context;
using CQRSApplication.Model;
using CQRSApplication.Query.UserQuery;
using Microsoft.EntityFrameworkCore;

namespace CQRSApplication.Test.UserControllersTest
{
    public class GetAllUserQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturn_AllUsersThatExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_GetAllUsers")
                .Options;

            using (var dbContext = new CQRSDbContext(options))
            {
                // Seed users
                var user1 = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Yash",
                    LastName = "Yadav",
                    PhoneNumber = "9898989898",
                    Address = "123 Main St",
                    UserCredentialsId = Guid.NewGuid(), // Ensure UserCredentialsId is set
                    userCredentials = new UserCredentials
                    {
                        UserName = "Yash.Yadav",
                        Password = "password123",
                        Email = "Yash.Yadav@example.com"
                    },
                    shippingAddress = new ShippingAddress
                    {
                        City = "City",
                        District = "District",
                        StreetAddress = "123 Street"
                    }
                };

                var user2 = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Amrit",
                    LastName = "Bista",
                    PhoneNumber = "0987654321",
                    Address = "456 Another St",
                    UserCredentialsId = Guid.NewGuid(), // Ensure UserCredentialsId is set
                    userCredentials = new UserCredentials
                    {
                        UserName = "Amrit.Bista",
                        Password = "password456",
                        Email = "Amrit.Bista@example.com"
                    },
                    shippingAddress = new ShippingAddress
                    {
                        City = "City",
                        District = "District",
                        StreetAddress = "456 Street"
                    }
                };

                dbContext.Users.Add(user1);
                dbContext.Users.Add(user2);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new CQRSDbContext(options))
            {
                var getAllUserQuery = new GetAllUserQuery();
                var handler = new GetAllUserQueryHandler(dbContext);
                var cancellationToken = new CancellationToken();

                // Act
                var result = await handler.Handle(getAllUserQuery, cancellationToken);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count);

                // Additional assertions
                var userYash = result.FirstOrDefault(u => u.FirstName == "Yash" && u.LastName == "Yadav");
                Assert.NotNull(userYash);
                Assert.Equal("Yash.Yadav", userYash.userCredentials.UserName);
                Assert.Equal("Yash.Yadav@example.com", userYash.userCredentials.Email);

                var userBista = result.FirstOrDefault(u => u.FirstName == "Amrit" && u.LastName == "Bista");
                Assert.NotNull(userBista);
                Assert.Equal("Amrit.Bista", userBista.userCredentials.UserName);
                Assert.Equal("Amrit.Bista@example.com", userBista.userCredentials.Email);
            }
        }
    }
}

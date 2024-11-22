
using CQRSApplication.Context;
using CQRSApplication.Model;
using CQRSApplication.Query.CustomerQuery;
using Microsoft.EntityFrameworkCore;

namespace CQRSApplication.Test.CartsTests
{
    public class GetCartQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturn_CartItems_WhenCartExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_GetCart")
                .Options;

            // Seed data: Create a user and their cart with items
            var userId = Guid.NewGuid();
            var cartId = Guid.NewGuid();

            using (var dbContext = new CQRSDbContext(options))
            {
                var user = new User
                {
                    Id = userId,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St",
                    CartId = cartId
                };

                var cart = new Cart
                {
                    Id = cartId,
                    CustomerId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Quantity = 2,
                            CartId = cartId
                        },
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Quantity = 1,
                            CartId = cartId
                        }
                    }
                };

                dbContext.Users.Add(user);
                dbContext.Carts.Add(cart);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new CQRSDbContext(options))
            {
                var getCartQuery = new GetCartQuery { CustomerId = userId };
                var handler = new GetCartQueryHandler(dbContext);
                var cancellationToken = new CancellationToken();

                // Act
                var result = await handler.Handle(getCartQuery, cancellationToken);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count); // Verify the number of items returned
                Assert.All(result, item => Assert.NotEqual(Guid.Empty, item.Id)); // Ensure each item has a non-empty Id
                Assert.All(result, item => Assert.Equal(cartId, item.CartId)); // Verify that each item's CartId matches the expected cartId
            }
        }
        [Fact]
        public async Task Handle_ShouldThrow_Exception_WhenCartDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_GetCart_NotFound")
                .Options;

            var userId = Guid.NewGuid();

            using (var dbContext = new CQRSDbContext(options))
            {
                var user = new User
                {
                    Id = userId,
                    FirstName = "Jane",
                    LastName = "Smith",
                    PhoneNumber = "0987654321",
                    Address = "456 Another St",
                    CartId = null
                    // No cart associated with this user
                };

                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new CQRSDbContext(options))
            {
                var getCartQuery = new GetCartQuery { CustomerId = userId };
                var handler = new GetCartQueryHandler(dbContext);
                var cancellationToken = new CancellationToken();

                // Act and Assert
                var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(getCartQuery, cancellationToken));
                Assert.Contains("Cart does not exist for the specified user id", exception.Message);
            }
        }

        [Fact]
        public async Task Handle_ShouldThrow_Exception_WhenCartIsEmpty()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CQRSDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_GetCart_Empty")
                .Options;

            var userId = Guid.NewGuid();
            var cartId = Guid.NewGuid();

            using (var dbContext = new CQRSDbContext(options))
            {
                var user = new User
                {
                    Id = userId,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St",
                    CartId = cartId
                };

                var cart = new Cart
                {
                    Id = cartId,
                    CustomerId = userId,
                    Items = new List<CartItem>()
                    // No items in the cart
                };

                dbContext.Users.Add(user);
                dbContext.Carts.Add(cart);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new CQRSDbContext(options))
            {
                var getCartQuery = new GetCartQuery { CustomerId = userId };
                var handler = new GetCartQueryHandler(dbContext);
                var cancellationToken = new CancellationToken();

                // Act and Assert
                var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(getCartQuery, cancellationToken));
                Assert.Contains("Cart is empty", exception.Message);
            }
        }
    }
}
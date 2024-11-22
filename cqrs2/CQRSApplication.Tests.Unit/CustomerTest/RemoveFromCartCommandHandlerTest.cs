using CQRSApplication.Command.CustomerCommand;
using CQRSApplication.Context;
using CQRSApplication.Model;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CQRSApplication.Tests.Unit.CustomerTest
{
    public class RemoveFromCartCommandHandlerTest
    {
        private CQRSDbContext _context;
        private readonly ITestOutputHelper output;
        public RemoveFromCartCommandHandlerTest(ITestOutputHelper output)
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            _context = new(optionsBuilder.Options);
            this.output = output;
        }
        [Fact]
        public async void Add_To_Cart_Handler_Test()
        {
            var userCredential = new UserCredentials
            {
                Id = Guid.NewGuid(),
                UserName = "Ramehs",
                Email = "aamritbistaa@gmail.com",
                Password = "123456",
                Role = RoleType.Customer,
                IsActive = false,
            };

            var _cartId = Guid.NewGuid();
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "aksd",
                LastName = "Asd",
                UserCredentialsId = userCredential.Id,
                Address = "shantinagar",
                PhoneNumber = "9843804968",
                CartId = _cartId,
            };
            var cart = new Cart
            {
                Id = _cartId,
                CustomerId = user.Id,
                Items = null,
            };

            await _context.UserCredentials.AddAsync(userCredential);
            await _context.Users.AddAsync(user);
            await _context.Carts.AddAsync(cart);

            var user1Credentials = new UserCredentials
            {
                Id = Guid.NewGuid(),
                Email = "test@test.com",
                UserName = "Vendor213",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            var user1 = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = user1Credentials.Id

            };
            var vendor1 = new Vendor
            {
                Id = Guid.NewGuid(),
                ShopAddress = "Shantinagar",
                ShopName = "New Fancy Store",
                PanNo = "9123912301923",
                UserId = user1.Id
            };

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "product1",
                Description = "this is product1",
                Category = "item category 1",
                Price = 120,
                Stock = 12,
                ImageUrl = "string",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                VendorId = vendor1.Id,
            };

            await _context.UserCredentials.AddAsync(user1Credentials);
            await _context.Users.AddAsync(user1);
            await _context.Vendors.AddAsync(vendor1);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var command = new RemoveFromCartCommand
            {
                CustomerId = user.Id,
                ProductId = product.Id,
                Quantity = 10
            };

            var handler = new RemoveFromCartCommandHandler(_context);
            var result = await handler.Handle(command, CancellationToken.None);
            var cartItem = await _context.CartItems.Where(x => x.CartId == user.CartId).ToListAsync();

            cartItem.Should().NotBeNull();
        }
    }
}

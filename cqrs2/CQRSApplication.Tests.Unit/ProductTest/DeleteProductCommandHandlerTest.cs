using CQRSApplication.Command.ProductCommand;
using CQRSApplication.Command.ProductCommandHandler;
using CQRSApplication.Context;
using CQRSApplication.Model;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CQRSApplication.Tests.Unit.ProductTest
{
    public class DeleteProductCommandHandlerTest
    {
        private CQRSDbContext _context;
        private readonly ITestOutputHelper output;

        public DeleteProductCommandHandlerTest(ITestOutputHelper output)
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            _context = new(optionsBuilder.Options);
            this.output = output;
        }

        [Fact]
        public async void Delete_product_command_handler_test()
        {
            var mediatorMock = new Mock<IMediator>();

            var User1 = new User
            {
                Id = new Guid("cb92efb3-ca01-48f6-91fa-6b2bf278771f"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = new Guid("42b6a1c9-4bc5-43cc-adc9-19ccadb999ee")

            };

            var user1Credentials = new UserCredentials
            {
                Id = new Guid("42b6a1c9-4bc5-43cc-adc9-19ccadb999ee"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            await _context.UserCredentials.AddAsync(user1Credentials);
            await _context.Users.AddAsync(User1);

            var vendor1 = new Vendor
            {
                Id = new Guid("fb93af2a-feb3-4df4-a7dc-ce0f18c67064"),
                ShopAddress = "Shantinagar",
                ShopName = "New Fancy Store",
                PanNo = "9123912301923",
                UserId = new Guid("cb92efb3-ca01-48f6-91fa-6b2bf278771f")
            };

            await _context.Vendors.AddAsync(vendor1);
            var item1 = new CreateProductCommand
            {
                Name = "Product 1",
                VendorId = new Guid("fb93af2a-feb3-4df4-a7dc-ce0f18c67064"),
                Price = 120,
                Stock = 100,
                Category = "asdasd",
                Description = "asdasd",
                Image = null
            };
            var handler1 = new CreateProductCommandHandler(_context, mediatorMock.Object);

            var result1 = await handler1.Handle(item1, CancellationToken.None);

            var item = _context.Products.FirstOrDefault();

            var command = new DeleteProductCommand
            {
                ProductId = item.Id,
                VendorId = item.VendorId
            };

            var handler = new DeleteProductCommandHandler(_context, mediatorMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Name.Should().Be(item.Name);
        }
    }
}

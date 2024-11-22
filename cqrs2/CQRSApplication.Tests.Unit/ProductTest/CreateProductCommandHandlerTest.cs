using CQRSApplication.Command.ProductCommand;
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
    public class CreateProductCommandHandlerTest
    {
        CQRSDbContext _context;
        private readonly ITestOutputHelper output;

        public CreateProductCommandHandlerTest(ITestOutputHelper output)
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            _context = new(optionsBuilder.Options);
            this.output = output;
        }
        [Fact]
        public async void Create_Product_Test()
        {
            var mediatorMock = new Mock<IMediator>();

            var user1Credentials = new UserCredentials
            {
                Id = new Guid("4e94c971-c524-4f5a-b998-5db4fa01ba2c"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            var User1 = new User
            {
                Id = new Guid("4e94c971-c524-4f5a-b998-5db4fa01ba2c"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = user1Credentials.Id

            };


            await _context.UserCredentials.AddAsync(user1Credentials);
            await _context.Users.AddAsync(User1);

            var vendor1 = new Vendor
            {
                Id = new Guid("3ae3f571-0a40-48cf-9a70-ac32ff75f8ff"),
                ShopAddress = "Shantinagar",
                ShopName = "New Fancy Store",
                PanNo = "9123912301923",
                UserId = User1.Id
            };

            await _context.Vendors.AddAsync(vendor1);

            await _context.SaveChangesAsync();
            var handler = new CreateProductCommandHandler(_context, mediatorMock.Object);

            var item = new CreateProductCommand
            {
                Name = "Product 1",
                VendorId = vendor1.Id,
                Price = 120,
                Stock = 100,
                Category = "asdasd",
                Description = "asdasd",
                Image = null
            };

            var result = await handler.Handle(item, CancellationToken.None);
            var item2 = new CreateProductCommand
            {
                Name = "Product 2",
                VendorId = vendor1.Id,
                Price = 120,
                Stock = 100,
                Category = "asdasd",
                Description = "asdasd",
                Image = null
            };
            var result2 = await handler.Handle(item2, CancellationToken.None);

            result.Name.Should().Be("Product 1");
            result2.Name.Should().Be("Product 2");
        }
    }
}

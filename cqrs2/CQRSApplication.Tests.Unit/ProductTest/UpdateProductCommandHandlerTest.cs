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
    public class UpdateProductCommandHandlerTest
    {
        private CQRSDbContext _context;
        private readonly ITestOutputHelper output;

        public UpdateProductCommandHandlerTest(ITestOutputHelper output)
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            _context = new(optionsBuilder.Options);
            this.output = output;
        }

        public async void Update_Product_Command_Test()
        {
            var mediatorMock = new Mock<IMediator>();

            var user1 = new User
            {
                Id = new Guid("3e81cf93-d29e-4f55-addd-0d5e78431c91"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = new Guid("d3c16ddb-e79c-4ee0-89bd-c51bc43d46ef")

            };

            var user1Credentials = new UserCredentials
            {
                Id = new Guid("d3c16ddb-e79c-4ee0-89bd-c51bc43d46ef"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            await _context.UserCredentials.AddAsync(user1Credentials);
            await _context.Users.AddAsync(user1);

            await _context.SaveChangesAsync();
            var vendor2 = new Vendor
            {
                Id = new Guid("5e8cae4c-b807-4376-a755-51f14ebe188d"),
                ShopAddress = "Shantinagar",
                ShopName = "New Fancy Store",
                PanNo = "9123912301923",
                UserId = new Guid("3e81cf93-d29e-4f55-addd-0d5e78431c91"),
            };

            await _context.Vendors.AddAsync(vendor2);
            await _context.SaveChangesAsync();
            var item = _context.Products.FirstOrDefault();
            var command = new UpdateProductCommand
            {
                ProductId = item.Id.ToString(),
                Name = item.Name,
                Description = item.Description,
                Price = item.Price - 20F,
                Category = item.Category,
                Stock = item.Stock - 20,
                VendorId = new Guid("5e8cae4c-b807-4376-a755-51f14ebe188d"),
            };
            var handler = new UpdateProductCommandHandler(_context, mediatorMock.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            result.Name.Should().Be(item.Name);
            result.Id.Should().Be(item.Id);
        }
    }
}

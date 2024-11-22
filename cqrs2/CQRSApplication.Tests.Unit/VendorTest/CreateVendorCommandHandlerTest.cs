using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CQRSApplication.Command.VendorCommand;
using CQRSApplication.Context;
using CQRSApplication.Model;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit.Abstractions;

namespace CQRSApplication.Tests.Unit.VendorTest
{
    public class CreateVendorCommandHandlerTest
    {

        private readonly ITestOutputHelper _output;
        CQRSDbContext context;
        public CreateVendorCommandHandlerTest(ITestOutputHelper output)
        {
            _output = output;
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            context = new(optionsBuilder.Options);
        }

        [Fact]
        public async void Create_vendor_command()
        {
            var user = new User
            {
                Id = new Guid("07593bc7-a76f-4150-9839-de656a799dd7"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = new Guid("10cf5ce7-9b74-4a90-b328-43a821090a0a")
            };

            var userCredentials = new UserCredentials
            {
                Id = new Guid("10cf5ce7-9b74-4a90-b328-43a821090a0a"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            await context.UserCredentials.AddAsync(userCredentials);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var item = new CreateVendorCommand
            {
                ShopName = "New Shoop Name",
                ShopAddress = "New Shop Address",
                PanNo = "Pan number of shop",
                UserId = user.Id,
            };
            var handler = new CreateVendorCommandHandler(context);
            var result = await handler.Handle(item, CancellationToken.None);
            _output.WriteLine(result.Id.ToString());
            result.Should().NotBeNull();
            result.ShopName.Should().Be(item.ShopName);
            result.ShopAddress.Should().Be(item.ShopAddress);
            result.PanNo.Should().Be(item.PanNo);
            result.UserId.Should().Be(user.Id);
        }
    }
}
using CQRSApplication.Command.VendorCommand;
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

namespace CQRSApplication.Tests.Unit.VendorTest
{
    public class UpdateVendorCommandHandlerTest
    {
        private readonly ITestOutputHelper _output;
        CQRSDbContext context;
        public UpdateVendorCommandHandlerTest(ITestOutputHelper output)
        {
            _output = output;
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            context = new(optionsBuilder.Options);
        }

        [Fact]
        public async void Update_vendor_command()
        {
            var user = new User
            {
                Id = new Guid("07693bc7-a76f-4150-9839-de656a799dd7"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = new Guid("11cf5ce7-9b74-4a90-b328-43a821090a0a")

            };

            var userCredentials = new UserCredentials
            {
                Id = new Guid("11cf5ce7-9b74-4a90-b328-43a821090a0a"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            await context.UserCredentials.AddAsync(userCredentials);
            await context.Users.AddAsync(user);

            var vendor = new Vendor
            {
                Id = new Guid("550916dc-80db-4789-a8e2-63ba1221a489"),
                ShopName = "New Shoop Name",
                ShopAddress = "New Shop Address",
                PanNo = "Pan number of shop",
                UserId = user.Id,
            };
            context.Vendors.Add(vendor);
            await context.SaveChangesAsync();

            var item = new UpdateVendorCommand
            {
                VendorId = new Guid("550916dc-80db-4789-a8e2-63ba1221a489"),
                ShopAddress = "Sinamangal",
                ShopName = "Shoe Shop",
                PanNo = "New updated pan no",
            };

            var handler = new UpdateVendorCommandHandler(context);
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

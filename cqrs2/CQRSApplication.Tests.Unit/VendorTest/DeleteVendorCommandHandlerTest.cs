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
    public class DeleteVendorCommandHandlerTest
    {
        private readonly ITestOutputHelper _output;
        CQRSDbContext context;
        public DeleteVendorCommandHandlerTest(ITestOutputHelper output)
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            context = new(optionsBuilder.Options);
            _output = output;
        }

        [Fact]
        public async Task Delete_vendor_commandAsync()
        {

            var userCredentials = new UserCredentials
            {
                Id = new Guid("b01c2d1e-86d6-40c1-a550-8cef4bf64d66"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            var user = new User
            {
                Id = new Guid("5974bee0-80f6-4e49-919f-dde5a0ff0818"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = userCredentials.Id

            };


            await context.UserCredentials.AddAsync(userCredentials);
            await context.Users.AddAsync(user);

            var vendor = new Vendor
            {
                Id = new Guid("b1f16af6-a0f4-45ae-9db6-245749a9003b"),
                ShopName = "New Shoop Name",
                ShopAddress = "New Shop Address",
                PanNo = "Pan number of shop",
                UserId = user.Id,
            };
            context.Vendors.Add(vendor);
            await context.SaveChangesAsync();


            var item = new DeleteVendorCommand
            {
                VendorId = vendor.Id,

                UserId = user.Id,
            };

            var handler = new DeleteVendorCommandHandler(context);
            var result = await handler.Handle(item, CancellationToken.None);

            result.Id.Should().Be(vendor.Id);
        }
    }
}

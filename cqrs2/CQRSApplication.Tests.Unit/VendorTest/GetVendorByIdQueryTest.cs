using CQRSApplication.Context;
using CQRSApplication.Model;
using CQRSApplication.Query.VendorQuery;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQRSApplication.Tests.Unit.VendorTest
{
    public class GetVendorByIdQueryTest
    {
        CQRSDbContext context;
        public GetVendorByIdQueryTest()
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            context = new(optionsBuilder.Options);
        }
        [Fact]
        public async void Get_Vendor_By_Id()
        {
            var userCredentials = new UserCredentials
            {
                Id = new Guid("6d61698e-6b4f-4d6d-9ea8-e437f9a3603a"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            var user = new User
            {
                Id = new Guid("b641167f-974f-425a-bfbc-2c1d946de9f1"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = userCredentials.Id,
            };
            var vendor = new Vendor
            {
                Id = new Guid("29c4ecba-15a9-4dfb-a728-15a3e995536a"),
                ShopName = "New Shoop Name",
                ShopAddress = "New Shop Address",
                PanNo = "Pan number of shop",
                UserId = user.Id,
            };


            var userCredentials1 = new UserCredentials
            {
                Id = new Guid("16c7027a-9e60-4aa2-ac73-7f50fcf45c07"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            var user1 = new User
            {
                Id = new Guid("d0a579e4-6565-43c3-81ff-0e62ed1a21a2"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = userCredentials1.Id,
            };

            var vendor1 = new Vendor
            {
                Id = new Guid("1923147e-a6a1-4c0c-b0b7-cb6e61a4e4c7"),
                ShopName = "New Shoop Name",
                ShopAddress = "New Shop Address",
                PanNo = "Pan number of shop",
                UserId = user1.Id,
            };

            await context.UserCredentials.AddAsync(userCredentials);
            await context.Users.AddAsync(user);
            await context.Vendors.AddAsync(vendor);

            await context.UserCredentials.AddAsync(userCredentials1);
            await context.Users.AddAsync(user1);
            await context.Vendors.AddAsync(vendor1);


            await context.SaveChangesAsync();

            var data = context.Vendors.ToList();
            var query = new GetVendorById
            {
                VendorId = new Guid("1923147e-a6a1-4c0c-b0b7-cb6e61a4e4c7"),
            };
            var handler = new GetVendorByIdHandler(context);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().Be(new Guid("1923147e-a6a1-4c0c-b0b7-cb6e61a4e4c7"));
        }
    }
}

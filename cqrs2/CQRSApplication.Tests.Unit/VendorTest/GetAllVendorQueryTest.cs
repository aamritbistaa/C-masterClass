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
using Xunit.Abstractions;

namespace CQRSApplication.Tests.Unit.VendorTest
{
    public class GetAllVendorQueryTest
    {
        private readonly ITestOutputHelper _output;
        private CQRSDbContext _context;
        public GetAllVendorQueryTest(ITestOutputHelper output)
        {
            _output = output;
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            _context = new(optionsBuilder.Options);

        }

        [Fact]
        public async void GetAll_vendor_query_test()
        {

            //foreach (var item in _context.Vendors)
            //{
            //    _context.Vendors.Remove(item);
            //}
            //await _context.SaveChangesAsync();

            var userCredentials = new UserCredentials
            {
                Id = new Guid("585862f4-69a3-4b06-b463-a5e989667880"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            var user = new User
            {
                Id = new Guid("ead13b5c-9c4b-48a1-ab3d-0bc332c87e20"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = userCredentials.Id,
            };
            var vendor = new Vendor
            {
                Id = new Guid("c9d998bc-0011-4b2e-a1c3-78fc360b2832"),
                ShopName = "New Shoop Name",
                ShopAddress = "New Shop Address",
                PanNo = "Pan number of shop",
                UserId = user.Id,
            };


            var userCredentials1 = new UserCredentials
            {
                Id = new Guid("f70e6948-d1fc-4ccb-bb29-f2cc8a5d19cd"),
                Email = "test@test.com",
                UserName = "User1",
                Password = "Papa",
                Role = RoleType.Vendor,
                IsActive = false
            };
            var user1 = new User
            {
                Id = new Guid("ef5494ef-a2a3-48e4-91fe-fca535e1c018"),
                FirstName = "User1",
                LastName = "string",
                PhoneNumber = "19239123123",
                Address = "Shantinagar",
                ImageUrl = "",
                UserCredentialsId = userCredentials1.Id,
            };

            var vendor1 = new Vendor
            {
                Id = new Guid("4b6f3cf5-f8a1-4f10-bad0-8cf41d4e0154"),
                ShopName = "New Shoop Name",
                ShopAddress = "New Shop Address",
                PanNo = "Pan number of shop",
                UserId = user1.Id,
            };

            await _context.UserCredentials.AddAsync(userCredentials);
            await _context.Users.AddAsync(user);
            await _context.Vendors.AddAsync(vendor);

            await _context.UserCredentials.AddAsync(userCredentials1);
            await _context.Users.AddAsync(user1);
            await _context.Vendors.AddAsync(vendor1);


            await _context.SaveChangesAsync();

            var data = _context.Vendors.ToList();
            var query = new GetAllVendorQuery();
            var handler = new GetAllVendorQueryHandler(_context);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeNullOrEmpty();

            //result.Count.Should().Be(2);
            //foreach ( var item in result )
            //{
            //    Console.WriteLine(item.Id);
            //}
            //result[0].Id.Should().Be(vendor.Id);
            //result[0].Id.Should().Be(vendor.Id);
            //result[1].Id.Should().Be(vendor1.Id);

        }
    }
}

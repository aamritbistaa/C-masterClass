using CQRSApplication.Command.CustomerCommand;
using CQRSApplication.Context;
using CQRSApplication.Model;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CQRSApplication.Tests.Unit.CustomerTest
{
    public class CreateCartCommandHandlerTest
    {
        CQRSDbContext _context;
        private readonly ITestOutputHelper output;

        public CreateCartCommandHandlerTest(ITestOutputHelper output)
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            _context = new(optionsBuilder.Options);
            this.output = output;
        }

        [Fact]
        public async void Create_Cart_Handler_Test()
        {
            var userCredential = new UserCredentials
            {
                Id = Guid.NewGuid(),
                UserName ="Ramehs",
                Email = "aamritbistaa@gmail.com",
                Password ="123456",
                Role=RoleType.Customer,
                IsActive=false,
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "aksd",
                LastName = "Asd",
                UserCredentialsId = userCredential.Id,
                Address="shantinagar",
                PhoneNumber="9843804968"
            };


            await _context.UserCredentials.AddAsync(userCredential);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();


            var item = new CreateCartCommand
            {
                CustomerId =user.Id,
            };

            var handler = new CreateCartCommandHandler(_context);
            var result = await handler.Handle(item,CancellationToken.None);
            result.Should().NotBeNull();

            var userInfo = await _context.Users.FindAsync(user.Id);

            result.Id.Should().NotBeEmpty();
            result.Id.Should().Be(userInfo.CartId.ToString());
            //result.Should().BeEquivalentTo<Guid>
        }
    }
}

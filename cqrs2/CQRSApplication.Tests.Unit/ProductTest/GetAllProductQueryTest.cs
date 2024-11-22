using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CQRSApplication.Context;
using CQRSApplication.Model;
using CQRSApplication.Query.ProductQuery;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace CQRSApplication.Tests.Unit.ProductTest
{
    public class GetAllProductQueryTest
    {
        private readonly ITestOutputHelper output;
        CQRSDbContext _context;

        public GetAllProductQueryTest(ITestOutputHelper output)
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            _context = new(optionsBuilder.Options);
            this.output = output;
        }
        [Fact]
        public async void GetAll_product_query()
        {
            output.WriteLine(_context.Products.Count().ToString());
            var item1 = new Product
            {
                Id = new Guid("a1cc8ef7-3ff3-4bec-884a-ef033b2acfa3"),
                Name = "Product 1",
                VendorId = new Guid("8b83afdf-ea34-44e5-84df-44f547cc53d0"),
                Price = 120,
                Stock = 100,
                Category = "asdasd",
                ImageUrl = "asd",
                Description = "asdasd"
            };

            await _context.Products.AddAsync(item1);

            var item2 = new Product
            {
                Id = new Guid("315af8e9-7ca2-48db-881d-c667df2b6519"),
                Name = "Product 2",
                VendorId = new Guid("2e294730-26f4-4f59-aac5-678f6b65c379"),
                Price = 120,
                Stock = 100,
                Category = "asdasd",
                ImageUrl = "asd",
                Description = "asdasd"
            };

            await _context.Products.AddAsync(item2);
            await _context.SaveChangesAsync();

            var handler = new GetAllProductQueryHandler(_context);
            var result = await handler.Handle(new GetAllProductQuery(), CancellationToken.None);
            result.Should().NotBeNullOrEmpty();
        }


    }
}
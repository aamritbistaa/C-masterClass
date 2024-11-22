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

namespace CQRSApplication.Tests.Unit.ProductTest
{
    public class GetProductByIdQueryTest
    {
        CQRSDbContext _context;
        public GetProductByIdQueryTest()
        {
            DbContextOptionsBuilder<CQRSDbContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
            _context = new(optionsBuilder.Options);
        }

        [Fact]
        public async void Get_Product_By_Id()
        {
            var item2 = new Product
            {
                Id = new Guid("215af8e9-7ca2-48db-881d-c667df2b6519"),
                Name = "Product 2",
                VendorId = new Guid("2e294730-26f4-4f59-aac5-678f6b65c379"),
                Price = 120,
                Stock = 100,
                Category = "asdasd",
                ImageUrl = "asd",
                Description = "asdasd"
            };
            await _context.Products.AddAsync(item2);
            _context.SaveChanges();

            var handler = new GetProductQueryHandler(_context);

            var result = await handler.Handle(new GetProductQuery
            {
                Id = new Guid("215af8e9-7ca2-48db-881d-c667df2b6519")
            }, CancellationToken.None);

            result.Name.Should().Be("Product 2");
        }

    }
}
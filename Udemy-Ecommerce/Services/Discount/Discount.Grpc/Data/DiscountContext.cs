using System;
using System.Security;
using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DiscountContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                Id = 1,
                Amount = 1000,
                Description = "First 10",
                ProductName = "First 10 Customer"
            }
        );
    }
}

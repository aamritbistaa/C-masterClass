using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configuration;

public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        //conversion from orderId value typee to guid
        builder.Property(x => x.Id).HasConversion(orderId => orderId.Value, dbId => OrderItemId.Of(dbId));

        builder.HasOne<Product>()
        .WithMany()
        .HasForeignKey(x => x.ProductId);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Price).IsRequired();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(orderId => orderId.Value,
        dbId => OrderId.Of(dbId));
        builder.HasOne<Customer>()
        .WithMany()
        .HasForeignKey(x => x.CustomerId)
        .IsRequired();
        builder.HasMany<OrderItem>()
        .WithOne()
        .HasForeignKey(x => x.OrderId);

        builder.ComplexProperty(x => x.OrderName, nameBuilder =>
        {
            nameBuilder.Property(x => x.Value)
            .HasColumnName(nameof(Order.OrderName))
            .HasMaxLength(100)
            .IsRequired();
        });

        builder.ComplexProperty(x => x.ShippingAddress, addressBuilder =>
        {
            addressBuilder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.EmailAddress)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.Country)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.State)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.ZipCode)
            .HasMaxLength(5)
            .IsRequired();
            addressBuilder.Property(x => x.AddressLine)
            .HasMaxLength(2000)
            .IsRequired();
        });

        builder.ComplexProperty(x => x.BillingAddress, addressBuilder =>
        {
            addressBuilder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.EmailAddress)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.Country)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.State)
            .HasMaxLength(50)
            .IsRequired();
            addressBuilder.Property(x => x.ZipCode)
            .HasMaxLength(5)
            .IsRequired();
            addressBuilder.Property(x => x.AddressLine)
            .HasMaxLength(2000)
            .IsRequired();
        });

        builder.ComplexProperty(x => x.Payment, paymentBuilder =>
        {
            paymentBuilder.Property(x => x.CardName)
            .HasMaxLength(50)
            .IsRequired();
            paymentBuilder.Property(x => x.CardNumber)
            .HasMaxLength(24)
            .IsRequired();
            paymentBuilder.Property(x => x.Expiration)
            .HasMaxLength(10);
            paymentBuilder.Property(x => x.CVV)
            .HasMaxLength(3);
            paymentBuilder.Property(x => x.PaymentMethod);
        });

        builder.Property(x => x.Status)
        .HasDefaultValue(OrderStatus.Draft)
        .HasConversion(x => x.ToString(),
        dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));
    }
}

using System;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionConfiguration : IEntityTypeConfiguration<ESubscriptions>
{
    public void Configure(EntityTypeBuilder<ESubscriptions> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .ValueGeneratedNever();

        // builder.Property("_adminId").HasColumnName("AdminId");

        builder.Property(s => s.SubscriptionType).HasConversion(s => s.Name,
        val => SubscriptionType.FromName(val, false));
    }
}

using System;
using System.Reflection;
using GymManagement.Application.Common.Interface;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistence;

public class GymManagementDbContext : DbContext, IUnitOfWork
{
    public GymManagementDbContext(DbContextOptions options) : base(options)
    {

    }

    protected GymManagementDbContext()
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ESubscriptions> Subscriptions { get; set; }


    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }
}

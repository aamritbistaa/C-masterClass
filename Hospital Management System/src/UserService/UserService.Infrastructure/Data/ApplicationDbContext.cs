using System;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Abstraction;
using UserService.Domain.Entity;
using UserService.Domain.Exceptions;

namespace UserService.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }

    public DbSet<EUser> Users { get; set; }
    public DbSet<EUserDocument> UserDocuments { get; set; }
    public DbSet<EOTP> OTPs { get; set; }

}

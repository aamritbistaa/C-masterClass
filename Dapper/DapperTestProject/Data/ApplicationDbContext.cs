using System;
using DapperTestProject.Entity;
using Microsoft.EntityFrameworkCore;

namespace DapperTestProject;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EUsers> Users { get; set; }
}

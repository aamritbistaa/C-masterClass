using System;
using Hangfire_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Hangfire_Test.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Student> Students { get; set; }
}

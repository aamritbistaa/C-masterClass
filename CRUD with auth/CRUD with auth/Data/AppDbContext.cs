using CRUD_with_auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD_with_auth.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
    }
}

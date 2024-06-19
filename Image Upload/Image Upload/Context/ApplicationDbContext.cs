using Image_Upload.Model;
using Microsoft.EntityFrameworkCore;

namespace Image_Upload.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}

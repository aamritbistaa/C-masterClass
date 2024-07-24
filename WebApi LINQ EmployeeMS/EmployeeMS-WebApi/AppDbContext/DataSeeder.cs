using EmployeeMS.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMS.AppDbContext
{
    public static class DataSeeder 
    {
        public static IApplicationBuilder UseItToSeedServer(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                DataSeeder.SeedDepartment(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error encountered while seeding");
            }

            return app;
        }
        public static void SeedDepartment(ApplicationDbContext context)
        {
            if (!context.Departments.Any())
            {
                var depts = new List<Department>
                {
                    new Department
                    {
                        Id = 1,
                        Name = "Dotnet"
                    },
                    new Department
                    {
                        Id = 2,
                        Name = "Frontend"
                    },
                    new Department
                    {
                        Id = 3,
                        Name = "Flutter"
                    },
                    new Department
                    {
                        Id = 4,
                        Name = "QA"
                    }
                };
                context.Departments.AddRange(depts);
                context.SaveChanges();
            }
        }
    }
}

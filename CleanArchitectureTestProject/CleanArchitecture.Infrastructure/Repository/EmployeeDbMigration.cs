using CleanArchitecture.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class EmployeeDbMigration
    {
        public static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = new AppDbContext(serviceScope.ServiceProvider.GetService<DbContextOptions<AppDbContext>>()))
                {
                    var databaseName = context.Database.GetDbConnection().Database;
                    if (databaseName == "employeeDb")
                    {
                        context.Database.Migrate();
                    }
                }
            }

        }
    }
}

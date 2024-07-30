using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Domain.Service.Interface;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repository;
using CleanArchitecture.Infrastructure.Service.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection service, IConfiguration configuration)
        {
            //db connection
            service.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]), ServiceLifetime.Scoped);


            service.AddScoped(typeof(IEmployeeRepository<>), typeof(EmployeeRepository<>)); // Register the generic repository
            service.AddScoped<IEmployeeServiceFactory, EmployeeServiceFactory>();

            service.AddScoped<IAddressService, AddressService>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IDepartmentService, DepartmentService>();
            service.AddScoped<IUserService, UserService>();

            return service;
        }
    }
}

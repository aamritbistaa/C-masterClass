using CleanArchitecture.Application.Manager.Implementation;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IEmployeeManager, EmployeeManager>();
            service.AddScoped<IAddressManager, AddressManager>();
            service.AddScoped<IDepartmentManager, DepartmentManager>();
            service.AddScoped<IUserManager, UserManager>();
            service.AddScoped<IViewManager, ViewManager>();
            return service;
        }
    }
}

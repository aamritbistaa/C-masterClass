using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace UserServie.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return service;
    }
}

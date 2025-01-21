using System;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
        });
        return service;
    }
}

using System;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection services)
    {
        return services;
    }
    public static WebApplication UserApiServies(this WebApplication app)
    {
        return app;
    }
}

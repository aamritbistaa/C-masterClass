using System;
using BuildingBlocks.Exception.Handler;
using Carter;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddHealthChecks();

        var connectionString = configuration.GetConnectionString("Default");

        services.AddHealthChecks().AddNpgSql(connectionString);
        return services;
    }
    public static WebApplication UserApiServies(this WebApplication app)
    {
        app.MapCarter();

        app.UseExceptionHandler(opt => { });

        app.UseHealthChecks("/health");
        return app;
    }
}

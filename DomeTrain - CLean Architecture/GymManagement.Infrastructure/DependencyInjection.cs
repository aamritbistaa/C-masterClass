using System;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Common.Persistence;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<GymManagementDbContext>(options => options.UseNpgsql("Server=localhost;Database=GymManagement;User Id=postgres;Password=Admin@123"));

        services.AddScoped<ISubscriptionRepository, SubscriptionsRepository>();
        services.AddScoped<IUnitOfWork>(ServiceProvider => ServiceProvider.GetRequiredService<GymManagementDbContext>());
        return services;
    }
}
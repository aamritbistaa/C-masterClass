using GymManagement.Application.Common.Interface;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        return service;
    }
}

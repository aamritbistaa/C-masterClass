using System;
using GymManagement.Application.Common.Interface;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionRepository : ISubscriptionRepository
{
    private static readonly List<ESubscriptions> _subscriptions = new();
    public Task AddSubscription(ESubscriptions request)
    {
        _subscriptions.Add(request);
        return Task.CompletedTask;
    }

    public async Task<ESubscriptions> GetSubscription(Guid id)
    {
        await Task.Delay(0);
        var data = _subscriptions.FirstOrDefault(s => s.Id == id);

        return data;
    }
}

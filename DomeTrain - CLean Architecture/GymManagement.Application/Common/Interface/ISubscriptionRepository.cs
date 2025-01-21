using System;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Common.Interface;

public interface ISubscriptionRepository
{
    Task AddSubscription(ESubscriptions request);
    Task<ESubscriptions> GetSubscription(Guid id);

}

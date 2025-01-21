using System;

namespace GymManagement.Domain.Subscriptions;

public class ESubscriptions
{
    public Guid Id { get; private set; }
    public SubscriptionType SubscriptionType { get; private set; }
    private readonly Guid _adminId;

    public ESubscriptions(SubscriptionType subscriptionType, Guid adminId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        SubscriptionType = subscriptionType;
        _adminId = adminId;
    }

    private ESubscriptions()
    {

    }
}


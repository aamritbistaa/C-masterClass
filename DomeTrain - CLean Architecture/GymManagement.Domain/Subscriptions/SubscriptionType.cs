using System;
using Ardalis.SmartEnum;

namespace GymManagement.Domain.Subscriptions;

public class SubscriptionType : SmartEnum<SubscriptionType>
{
    public static readonly SubscriptionType Free = new(nameof(Free), 1);
    public static readonly SubscriptionType Starter = new(nameof(Starter), 2);
    public static readonly SubscriptionType Pro = new(nameof(Pro), 3);
    public SubscriptionType(string name, int value) : base(name, value)
    {
    }
}

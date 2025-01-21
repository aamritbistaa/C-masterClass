namespace GymManagement.Contracts.Subscriptions;

public record class SubscriptionResponse
{
    public Guid Id { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public SubscriptionResponse(Guid Id, SubscriptionType SubscriptionType)
    {
        this.Id = Id;
        this.SubscriptionType = SubscriptionType;
    }
}

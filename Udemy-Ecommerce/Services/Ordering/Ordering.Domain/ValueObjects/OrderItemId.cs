namespace Ordering.Domain.ValueObjects;

public record class OrderItemId
{
    public Guid Value { get; }
    private OrderItemId(Guid value) => Value = value;
    public static OrderItemId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new Exception("OrderItemId cannot be empty");
        }
        return new OrderItemId(value);
    }
}

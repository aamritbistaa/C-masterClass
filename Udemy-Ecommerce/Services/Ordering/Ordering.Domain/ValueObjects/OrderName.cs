namespace Ordering.Domain.ValueObjects;

public record class OrderName
{
    public string Value { get; }
    private OrderName(string value) => Value = value;
    public static OrderName Of(string value)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
        return new OrderName(value);
    }
}

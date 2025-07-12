using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects;

public record class ProductId
{
    public Guid Value { get; }
    private ProductId(Guid value) => Value = value;
    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("Customer Id cannot be null");
        }
        return new ProductId(value);
    }
}
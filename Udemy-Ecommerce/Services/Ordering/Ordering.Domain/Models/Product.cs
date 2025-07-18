using Ordering.Domain.Abstraction;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default;
    public decimal Price { get; private set; } = default;
    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        var customer = new Product
        {
            Id = id,
            Name = name,
            Price = price
        };
        return customer;
    }
}

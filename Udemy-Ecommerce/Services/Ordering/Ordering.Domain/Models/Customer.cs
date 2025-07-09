using System;
using Ordering.Domain.Abstraction;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default;
    public string Email { get; private set; } = default;
}

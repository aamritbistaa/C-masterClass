using System;

namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string? CardName { get; private set; } = default;
    public string CardNumber { get; private set; } = default;
    public string Expiration { get; private set; } = default;
    public string CVV { get; private set; } = default;
    public int PaymentMethod { get; private set; } = default;

    public static Payment Of(string? cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        return new Payment
        {
            CardName = cardName,
            CardNumber = cardNumber,
            Expiration = expiration,
            CVV = cvv,
            PaymentMethod = paymentMethod
        };
    }
}

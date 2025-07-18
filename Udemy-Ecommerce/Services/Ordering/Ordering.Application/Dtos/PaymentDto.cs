namespace Ordering.Application.Dtos;

public record class PaymentDto(
    string CardName,
    string CardNumber,
    string Expiration,
    string Cvv,
    int PaymentMethhod
);
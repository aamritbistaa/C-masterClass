namespace Bookify.Domain.Apartments;

public record Currency
{
    internal static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency None = new("");
    private Currency(string code)
    {
        Code = code;
    }
    public string Code { get; init; }

    public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, Eur };

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? throw new Exception("The currency code is invalid");
    }

}

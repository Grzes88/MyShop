using MyShop.Core.Exceptions;

namespace MyShop.Core.ValueObjects;

public sealed record Price()
{
    public decimal Value { get; }

    public Price(decimal value) : this()
    {
        if (value <= decimal.Zero)
            throw new InvalidPriceException(value);

        Value = value;
    }

    public static implicit operator Price(decimal value)
        => new(value);

    public static implicit operator decimal(Price price)
        => price.Value;
}

using MyShop.Core.Exceptions;

namespace MyShop.Core.ValueObjects;

public sealed record Price()
{
    public double Value { get; }

    public Price(double value) : this()
    {
        if (value < 0 || double.IsInfinity(value))
            throw new InvalidPriceException(value);

        Value = value;
    }

    public static implicit operator Price(double value)
        => new(value);

    public static implicit operator double(Price price)
        => price.Value;
}

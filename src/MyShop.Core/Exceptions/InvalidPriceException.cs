namespace MyShop.Core.Exceptions;

public sealed class InvalidPriceException : CustomException
{
    public decimal Price { get; }

    public InvalidPriceException(decimal price) : base($"Price: {price} is invalid") 
        => Price = price;
}

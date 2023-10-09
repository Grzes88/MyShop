namespace MyShop.Core.Exceptions;

public sealed class InvalidPriceException : CustomException
{
    public double Price { get; }

    public InvalidPriceException(double price) : base($"Price: {price} is invalid") 
        => Price = price;
}

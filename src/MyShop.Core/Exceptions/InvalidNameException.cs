namespace MyShop.Core.Exceptions;

public sealed class InvalidNameException : CustomException
{
    public InvalidNameException() : base($"Product name is invalid")
    {
    }
}

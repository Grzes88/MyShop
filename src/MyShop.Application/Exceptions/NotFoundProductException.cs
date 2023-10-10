using MyShop.Core.Exceptions;

namespace MyShop.Application.Exceptions;

public class NotFoundProductException : CustomException
{
    public Guid Id { get; }

    public NotFoundProductException(Guid id) : base($"Product with Id: {id} was not found") 
        => Id = id;
}

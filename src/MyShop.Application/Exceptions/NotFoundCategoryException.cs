using MyShop.Core.Exceptions;

namespace MyShop.Application.Exceptions;

public class NotFoundCategoryException : CustomException
{
    public Guid Id { get; }

    public NotFoundCategoryException(Guid id) : base($"Category with Id: {id} was not found") 
        => Id = id;
}

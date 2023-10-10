using MyShop.Application.Abstractions;
using MyShop.Application.Exceptions;
using MyShop.Core.Repositories;
using MyShop.Core.ValueObjects;

namespace MyShop.Application.Commands.Handlers;

public sealed class UpdateProductHandler : ICommandHandler<UpdateProduct>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository) 
        => _productRepository = productRepository;

    public async Task HandleAsync(UpdateProduct command)
    {
        var productId = new ProductId(command.ProductId);
        var product = await _productRepository.GetProductAsync(productId);

        if (product is null)
        {
            throw new NotFoundCategoryException(productId);
        }

        product.Update(command.Name, command.Description, command.Price, command.CategoryId);
    }
}

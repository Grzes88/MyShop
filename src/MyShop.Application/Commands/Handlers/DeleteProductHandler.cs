using MyShop.Application.Abstractions;
using MyShop.Application.Exceptions;
using MyShop.Core.Repositories;
using MyShop.Core.ValueObjects;

namespace MyShop.Application.Commands.Handlers;

public sealed class DeleteProductHandler : ICommandHandler<DeleteProduct>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository) 
        => _productRepository = productRepository;

    public async Task HandleAsync(DeleteProduct command)
    {
        var productId = new ProductId(command.ProductId);
        var product = await _productRepository.GetProductAsync(productId);

        if(product is null) 
        {
            throw new NotFoundProductException(productId);
        }

        _productRepository.DeleteProduct(product);
    }
}

using MyShop.Application.Abstractions;
using MyShop.Core.Entities;
using MyShop.Core.Repositories;

namespace MyShop.Application.Commands.Handlers;

public sealed class CreateProductHandler : ICommandHandler<CreateProduct>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository) 
        => _productRepository = productRepository;

    public async Task HandleAsync(CreateProduct command)
    {
        var product =  Product.Create(command.Name, command.Description, command.Price, command.CategoryId);

        await _productRepository.AddProductAsync(product);
    }
}

using MyShop.Application.Abstractions;
using MyShop.Application.DTO;
using MyShop.Application.Queries;
using MyShop.Core.Repositories;

namespace MyShop.Infrastructure.DAL.Handlers;

public sealed class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsHandler(IProductRepository productRepository)
        => _productRepository = productRepository;

    public async Task<IEnumerable<ProductDto>> HandleAsync(GetProducts query)
    {
        var products = await _productRepository.GetProductsAsync();

        return products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price, p.CategoryId));
    }
}

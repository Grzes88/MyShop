using Microsoft.EntityFrameworkCore;
using MyShop.Application.Abstractions;
using MyShop.Application.DTO;
using MyShop.Application.Exceptions;
using MyShop.Application.Queries;
using MyShop.Core.ValueObjects;

namespace MyShop.Infrastructure.DAL.Handlers;

public sealed class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
{
    private readonly MyShopDbContext _dbContext;

    public GetProductHandler(MyShopDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<ProductDto> HandleAsync(GetProduct query)
    {
        var productId = new ProductId(query.ProductId);
        var product = await _dbContext.Products
            .AsNoTracking()
            .Select(Extensions.AsProductDto())
            .SingleOrDefaultAsync(p => p.Id == productId.Value);

        if (product is null)
            throw new NotFoundProductException(productId);

        return product;
    }
}

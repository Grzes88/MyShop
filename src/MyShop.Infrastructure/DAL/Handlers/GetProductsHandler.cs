using Microsoft.EntityFrameworkCore;
using MyShop.Application.Abstractions;
using MyShop.Application.DTO;
using MyShop.Application.Queries;

namespace MyShop.Infrastructure.DAL.Handlers;

public sealed class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<ProductDto>>
{
    private readonly MyShopDbContext _dbContext;

    public GetProductsHandler(MyShopDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<IEnumerable<ProductDto>> HandleAsync(GetProducts query) 
        => await _dbContext.Products
            .AsNoTracking()
            .Include(x => x.Category)
            .Select(Extensions.AsProductDto())
            .ToListAsync();
}

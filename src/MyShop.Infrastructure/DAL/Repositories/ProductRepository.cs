using MyShop.Core.Entities;
using MyShop.Core.Repositories;

namespace MyShop.Infrastructure.DAL.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly MyShopDbContext _dbContext;

    public ProductRepository(MyShopDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task AddProductAsync(Product product)
        => await _dbContext.Products.AddAsync(product);
}

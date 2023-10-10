using Microsoft.EntityFrameworkCore;
using MyShop.Core.Entities;
using MyShop.Core.Repositories;
using MyShop.Core.ValueObjects;

namespace MyShop.Infrastructure.DAL.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly MyShopDbContext _dbContext;

    public ProductRepository(MyShopDbContext dbContext)
        => _dbContext = dbContext;

    public async Task AddProductAsync(Product product)
        => await _dbContext.Products.AddAsync(product);

    public void DeleteProduct(Product? product)
        => _dbContext.Products.Remove(product);

    public async Task<Product?> GetProductAsync(ProductId id)
        => await _dbContext.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
}

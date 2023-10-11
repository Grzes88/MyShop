using MyShop.Core.Entities;
using MyShop.Core.ValueObjects;

namespace MyShop.Core.Repositories;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task<Product?> GetProductAsync(ProductId id);
    Task<IEnumerable<Product?>> GetProductsAsync();
    void DeleteProduct(Product? product);
}

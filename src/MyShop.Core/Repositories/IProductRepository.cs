using MyShop.Core.Entities;

namespace MyShop.Core.Repositories;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
}

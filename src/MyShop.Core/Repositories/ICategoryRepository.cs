using MyShop.Core.Entities;

namespace MyShop.Core.Repositories;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category);
}

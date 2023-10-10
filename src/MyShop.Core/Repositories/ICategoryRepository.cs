using MyShop.Core.Entities;
using MyShop.Core.ValueObjects;

namespace MyShop.Core.Repositories;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category);
    Task<Category?> GetCategoryAsync(CategoryId id);
    void DeleteCategory(Category? category);
}

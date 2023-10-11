using MyShop.Core.Entities;
using MyShop.Core.ValueObjects;

namespace MyShop.Core.Repositories;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category);
    Task<Category?> GetCategoryAsync(CategoryId id);
    Task<IEnumerable<Category?>> GetCategoriesAsync();
    void DeleteCategory(Category? category);
}

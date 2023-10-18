using Microsoft.EntityFrameworkCore;
using MyShop.Core.Entities;
using MyShop.Core.Repositories;
using MyShop.Core.ValueObjects;

namespace MyShop.Infrastructure.DAL.Repositories;

internal sealed class CategoryRepository : ICategoryRepository
{
    private readonly MyShopDbContext _dbContext;

    public CategoryRepository(MyShopDbContext dbContext)
        => _dbContext = dbContext;

    public async Task AddCategoryAsync(Category category)
        => await _dbContext.Categories.AddAsync(category);

    public void DeleteCategory(Category? category)
        => _dbContext.Categories.Remove(category);

    public async Task<IEnumerable<Category?>> GetCategoriesAsync()
        => await _dbContext.Categories
            .ToListAsync();

    public async Task<Category?> GetCategoryAsync(CategoryId id) 
        => await _dbContext.Categories
                .SingleOrDefaultAsync(c => c.Id == id);
}

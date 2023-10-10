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

    public async Task<Category?> GetCategoryAsync(CategoryId id) 
        => await _dbContext.Categories
        .Include(c => c.Products)
        .FirstOrDefaultAsync(x => x.Id == id);
}

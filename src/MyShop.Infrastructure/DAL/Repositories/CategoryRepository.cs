using MyShop.Core.Entities;
using MyShop.Core.Repositories;

namespace MyShop.Infrastructure.DAL.Repositories;

internal sealed class CategoryRepository : ICategoryRepository
{
    private readonly MyShopDbContext _dbContext;

    public CategoryRepository(MyShopDbContext dbContext)
        => _dbContext = dbContext;

    public async Task AddCategoryAsync(Category category)
        => await _dbContext.Categories.AddAsync(category);

}

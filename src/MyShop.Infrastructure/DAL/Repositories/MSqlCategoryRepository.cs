using MyShop.Core.Entities;
using MyShop.Core.Repositories;

namespace MyShop.Infrastructure.DAL.Repositories;

internal sealed class MSqlCategoryRepository : ICategoryRepository
{
    private readonly MyShopDbContext _dbContext;

    public MSqlCategoryRepository(MyShopDbContext dbContext)
        => _dbContext = dbContext;

    public async Task AddCategoryAsync(Category category)
        => await _dbContext.Categories.AddAsync(category);

}

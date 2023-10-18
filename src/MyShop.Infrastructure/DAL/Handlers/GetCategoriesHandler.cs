using Microsoft.EntityFrameworkCore;
using MyShop.Application.Abstractions;
using MyShop.Application.DTO;
using MyShop.Application.Queries;

namespace MyShop.Infrastructure.DAL.Handlers;

public sealed class GetCategoriesHandler : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly MyShopDbContext _dbContext;

    public GetCategoriesHandler(MyShopDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query) 
        => await _dbContext.Categories
            .AsNoTracking()
            .Select(Extensions.AsCategoryDto())
            .ToListAsync();
}

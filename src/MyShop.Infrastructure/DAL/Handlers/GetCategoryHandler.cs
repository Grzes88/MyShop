using Microsoft.EntityFrameworkCore;
using MyShop.Application.Abstractions;
using MyShop.Application.DTO;
using MyShop.Application.Exceptions;
using MyShop.Application.Queries;
using MyShop.Core.ValueObjects;

namespace MyShop.Infrastructure.DAL.Handlers;

public sealed class GetCategoryHandler : IQueryHandler<GetCategory, CategoryDto>
{
    private readonly MyShopDbContext _dbContext;

    public GetCategoryHandler(MyShopDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<CategoryDto> HandleAsync(GetCategory query)
    {
        var categoryId = new CategoryId(query.CategoryId);
        var categoryDto = await _dbContext.Categories
            .AsNoTracking()
            .Select(Extensions.AsCategoryDto())
            .FirstOrDefaultAsync(x => x.Id == categoryId.Value);

        if (categoryDto is null)
            throw new NotFoundCategoryException(categoryId);

        return categoryDto;
    }
}

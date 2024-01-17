using MyShop.Application.Abstractions;
using MyShop.Application.DTO;
using MyShop.Application.Queries;
using SoapService.CategoryService;

namespace MyShop.Infrastructure.DAL.Handlers;

public sealed class GetCategoriesHandler : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesHandler(ICategoryService categoryService) 
        => _categoryService = categoryService;

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query)
    {
        var categories = await _categoryService.GetAllCategoryAsync();

        return categories.Select(c => new CategoryDto { Id = c.Id, Name = c.Name});
    }
}

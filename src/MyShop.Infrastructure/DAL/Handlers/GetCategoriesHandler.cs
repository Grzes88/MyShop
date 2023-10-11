using MyShop.Application.Abstractions;
using MyShop.Application.DTO;
using MyShop.Application.Queries;
using MyShop.Core.Repositories;

namespace MyShop.Infrastructure.DAL.Handlers;

public sealed class GetCategoriesHandler : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesHandler(ICategoryRepository categoryRepository) 
        => _categoryRepository = categoryRepository;

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query)
    {
        var categories = await _categoryRepository.GetCategoriesAsync();

        return categories.Select(c => new CategoryDto(c.Id, c.Name));
    }
}

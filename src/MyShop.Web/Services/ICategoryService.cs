using MyShop.Web.DTO;

namespace MyShop.Web.Services;

public interface ICategoryService
{
    Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task<IEnumerable<CategoryDto>?> GetCategoriesAsync();
    Task<CategoryDto?> GetCategoryAsync(Guid id);
    Task<HttpResponseMessage> DeleteCategoryAsync(Guid id);
    Task<HttpResponseMessage> UpdateCategoryAsync(Guid id, UpdateCategoryDto updateCategoryDto);
}

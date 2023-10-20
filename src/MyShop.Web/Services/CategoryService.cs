using MyShop.Web.DTO;
using System.Net.Http.Json;

namespace MyShop.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient) 
        => _httpClient = httpClient;

    public async Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto) 
        => await _httpClient.PostAsJsonAsync("category", createCategoryDto);

    public async Task DeleteCategoryAsync(Guid id)
        => await _httpClient.DeleteAsync($"category/{id}");

    public async Task<IEnumerable<CategoryDto>?> GetCategoriesAsync() 
        => await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>?>("categories");

    public async Task<CategoryDto?> GetCategoryAsync(Guid id) 
        => await _httpClient.GetFromJsonAsync<CategoryDto?>($"category/{id}");
}

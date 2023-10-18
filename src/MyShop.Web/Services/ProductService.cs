using MyShop.Web.DTO;
using System.Net.Http.Json;

namespace MyShop.Web.Services;

public sealed class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task CreateProductAsync(CreateProductDto createProductDto)
        => await _httpClient.PostAsJsonAsync("product", createProductDto);

    public async Task DeleteProductAsync(Guid id)
        => await _httpClient.DeleteAsync($"product/{id}");

    public async Task<IEnumerable<ProductDto>?> GetProductsAsync()
        => await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>?>("products");

    public async Task<ProductDto?> GetProductAsync(Guid id)
        => await _httpClient.GetFromJsonAsync<ProductDto>($"product/{id}");

    public async Task UpdateProductAsync(Guid id, UpdateProductDto updateProductDto)
     => await _httpClient.PutAsJsonAsync($"product/{id}", updateProductDto);
}
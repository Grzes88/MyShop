using MyShop.Web.DTO;

namespace MyShop.Web.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>?> GetProductsAsync();
    Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto);
    Task<ProductDto?> GetProductAsync(Guid id);
    Task DeleteProductAsync(Guid id);
}

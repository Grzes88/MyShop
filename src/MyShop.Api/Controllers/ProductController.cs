using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Abstractions;
using MyShop.Application.Commands;

namespace MyShop.Api.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICommandHandler<CreateProduct> _createProductHandler;

    public ProductController(ICommandHandler<CreateProduct> createProductHandler)
    {
        _createProductHandler = createProductHandler;
    }

    [HttpPost("Product")]
    public async Task<IActionResult> CreateProduct(CreateProduct createProduct)
    {
        await _createProductHandler.HandleAsync(createProduct);
        return NoContent();
    }
}

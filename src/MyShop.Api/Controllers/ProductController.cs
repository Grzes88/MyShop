using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Abstractions;
using MyShop.Application.Commands;

namespace MyShop.Api.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICommandHandler<CreateProduct> _createProductHandler;
    private readonly ICommandHandler<UpdateProduct> _updateProductHandler;
    private readonly ICommandHandler<DeleteProduct> _deleteProductHandler;

    public ProductController(ICommandHandler<CreateProduct> createProductHandler,
        ICommandHandler<UpdateProduct> updateProductHandler,
        ICommandHandler<DeleteProduct> deleteProductHandler)
    {
        _createProductHandler = createProductHandler;
        _updateProductHandler = updateProductHandler;
        _deleteProductHandler = deleteProductHandler;
    }

    [HttpPost("Product")]
    public async Task<IActionResult> CreateProduct(CreateProduct command)
    {
        await _createProductHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("product/{productId:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid productId, UpdateProduct command)
    {
        await _updateProductHandler.HandleAsync(command with { ProductId = productId });
        return NoContent();
    } 
    
    [HttpDelete("product/{productId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        await _deleteProductHandler.HandleAsync(new DeleteProduct(productId));
        return NoContent();
    }
}

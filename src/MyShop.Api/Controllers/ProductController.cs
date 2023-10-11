using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Abstractions;
using MyShop.Application.Commands;
using MyShop.Application.DTO;
using MyShop.Application.Queries;

namespace MyShop.Api.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICommandHandler<CreateProduct> _createProductHandler;
    private readonly ICommandHandler<UpdateProduct> _updateProductHandler;
    private readonly ICommandHandler<DeleteProduct> _deleteProductHandler;
    private readonly IQueryHandler<GetProducts, IEnumerable<ProductDto>> _getProductsHandler;

    public ProductController(ICommandHandler<CreateProduct> createProductHandler,
        ICommandHandler<UpdateProduct> updateProductHandler,
        ICommandHandler<DeleteProduct> deleteProductHandler,
        IQueryHandler<GetProducts, IEnumerable<ProductDto>> getProductsHandler)
    {
        _createProductHandler = createProductHandler;
        _updateProductHandler = updateProductHandler;
        _deleteProductHandler = deleteProductHandler;
        _getProductsHandler = getProductsHandler;
    }

    [HttpPost("Product")]
    public async Task<ActionResult> CreateProduct(CreateProduct command)
    {
        await _createProductHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("product/{productId:guid}")]
    public async Task<ActionResult> UpdateProduct(Guid productId, UpdateProduct command)
    {
        await _updateProductHandler.HandleAsync(command with { ProductId = productId });
        return NoContent();
    } 
    
    [HttpDelete("product/{productId:guid}")]
    public async Task<ActionResult> DeleteProduct(Guid productId)
    {
        await _deleteProductHandler.HandleAsync(new DeleteProduct(productId));
        return NoContent();
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] GetProducts queries) 
        => Ok(await _getProductsHandler.HandleAsync(queries));
}

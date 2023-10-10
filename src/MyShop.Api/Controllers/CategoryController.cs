using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Abstractions;
using MyShop.Application.Commands;

namespace MyShop.Api.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICommandHandler<CreateCategory> _createCategoryHandler;

    public CategoryController(ICommandHandler<CreateCategory> createCategoryHandler)
    {
        _createCategoryHandler = createCategoryHandler;
    }

    [HttpPost("category")]
    public async Task<ActionResult> CreateCategory(CreateCategory category)
    {
        await _createCategoryHandler.HandleAsync(category);
        return NoContent();
    }
}

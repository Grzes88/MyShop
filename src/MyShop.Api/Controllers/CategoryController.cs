using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Abstractions;
using MyShop.Application.Commands;
using MyShop.Application.DTO;
using MyShop.Application.Queries;

namespace MyShop.Api.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICommandHandler<CreateCategory> _createCategoryHandler;
    private readonly ICommandHandler<UpdateCategory> _updateCategoryHandler;
    private readonly ICommandHandler<DeleteCategory> _deleteCategoryHandler;
    private readonly IQueryHandler<GetCategories, IEnumerable<CategoryDto>> _getCategoriesHandler;

    public CategoryController(ICommandHandler<CreateCategory> createCategoryHandler,
        ICommandHandler<UpdateCategory> updateCategoryHandler,
        ICommandHandler<DeleteCategory> deleteCategoryHandler,
        IQueryHandler<GetCategories, IEnumerable<CategoryDto>> getCategoriesHandler)
    {
        _createCategoryHandler = createCategoryHandler;
        _updateCategoryHandler = updateCategoryHandler;
        _deleteCategoryHandler = deleteCategoryHandler;
        _getCategoriesHandler = getCategoriesHandler;
    }

    [HttpPost("category")]
    public async Task<IActionResult> CreateCategory(CreateCategory command)
    {
        await _createCategoryHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("category/{categoryId:guid}")]
    public async Task<IActionResult> UpdateCategory(Guid categoryId, UpdateCategory command)
    {
        await _updateCategoryHandler.HandleAsync(command with { CategoryId = categoryId });
        return NoContent();
    }

    [HttpDelete("category/{categoryId:guid}")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        await _deleteCategoryHandler.HandleAsync(new DeleteCategory(categoryId));
        return NoContent();
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories([FromQuery] GetCategories queries)
        => Ok(await _getCategoriesHandler.HandleAsync(queries));
}
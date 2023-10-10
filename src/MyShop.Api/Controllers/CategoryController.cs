using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Abstractions;
using MyShop.Application.Commands;

namespace MyShop.Api.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICommandHandler<CreateCategory> _createCategoryHandler;
    private readonly ICommandHandler<UpdateCategory> _updateCategoryHandler;
    private readonly ICommandHandler<DeleteCategory> _deleteCategoryHandler;

    public CategoryController(ICommandHandler<CreateCategory> createCategoryHandler,
        ICommandHandler<UpdateCategory> updateCategoryHandler,
        ICommandHandler<DeleteCategory> deleteCategoryHandler)
    {
        _createCategoryHandler = createCategoryHandler;
        _updateCategoryHandler = updateCategoryHandler;
        _deleteCategoryHandler = deleteCategoryHandler;
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
}

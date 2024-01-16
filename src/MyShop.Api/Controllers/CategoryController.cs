using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Abstractions;
using MyShop.Application.Commands;
using MyShop.Application.DTO;
using MyShop.Application.Queries;
using static SoapApi.CategoryServiceContract;

namespace MyShop.Api.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICommandHandler<CreateCategory> _createCategoryHandler;
    private readonly ICommandHandler<UpdateCategory> _updateCategoryHandler;
    private readonly ICommandHandler<DeleteCategory> _deleteCategoryHandler;
    private readonly IQueryHandler<GetCategory, CategoryDto> _getCategoryHandler;
    private readonly ICategoryService _categoryService;

    public CategoryController(ICommandHandler<CreateCategory> createCategoryHandler,
        ICommandHandler<UpdateCategory> updateCategoryHandler,
        ICommandHandler<DeleteCategory> deleteCategoryHandler,
        IQueryHandler<GetCategories, IEnumerable<CategoryDto>> getCategoriesHandler,
        IQueryHandler<GetCategory, CategoryDto> getCategoryHandler, ICategoryService categoryService)
    {
        _createCategoryHandler = createCategoryHandler;
        _updateCategoryHandler = updateCategoryHandler;
        _deleteCategoryHandler = deleteCategoryHandler;
        _getCategoryHandler = getCategoryHandler;
        _categoryService = categoryService;
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
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories( )
    => Ok(await _categoryService.GetAllCategoryAsync());

    [HttpGet("category/{categoryId:guid}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(Guid categoryId)
        => Ok(await _getCategoryHandler.HandleAsync(new GetCategory(categoryId)));
}
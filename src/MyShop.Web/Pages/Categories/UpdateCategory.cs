using Microsoft.AspNetCore.Components;
using MyShop.Web.DTO;
using MyShop.Web.Services;

namespace MyShop.Web.Pages.Categories;

public partial class UpdateCategory
{
    [Inject]
    public ICategoryService CategoryService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string CategoryId { get; set; }

    public CategoryDto CategoryDto { get; set; } = new CategoryDto();
    public UpdateCategoryDto UpdateCategoryDto { get; set; } = new UpdateCategoryDto();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected override async Task OnInitializedAsync()
    {
        Saved = false;

        if (Guid.TryParse(CategoryId, out var categoryId))
        {
            CategoryDto = await CategoryService.GetCategoryAsync(categoryId);
        }
    }

    protected async Task HandleValidSubmit()
    {
        Saved = false;

        var updateCategoryDto = new UpdateCategoryDto
        {
            Name = CategoryDto.Name
        };
        await CategoryService.UpdateCategoryAsync(Guid.Parse(CategoryId), updateCategoryDto);

        StatusClass = "alert-success";
        Message = "Category updated successfully.";
        Saved = true;
    }

    protected void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/overviewcategory");
    }
}

using Microsoft.AspNetCore.Components;
using MyShop.Web.DTO;
using MyShop.Web.Services;

namespace MyShop.Web.Pages.Categories;

public partial class CreateCategory
{
    [Inject]
    public ICategoryService CategoryService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string CategoryId { get; set; }

    public CreateCategoryDto CreateCategoryDto { get; set; }
    public CategoryDto CategoryDto { get; set; } = new CategoryDto();


    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected async Task HandleValidSubmit()
    {
        Saved = false;
        var createCategoryDto = new CreateCategoryDto(CategoryDto.Name);

        var isAddCategory = await CategoryService.CreateCategoryAsync(createCategoryDto);
        if (isAddCategory)
        {
            StatusClass = "alert-success";
            Message = "New category added successfully.";
            Saved = true;
        }
        else
        {
            StatusClass = "alert-danger";
            Message = "Something went wrong adding the new category. Please try again.";
            Saved = false;
        }
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
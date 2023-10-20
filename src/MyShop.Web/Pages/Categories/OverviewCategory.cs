using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyShop.Web.Components;
using MyShop.Web.DTO;
using MyShop.Web.Services;

namespace MyShop.Web.Pages.Categories;

public partial class OverviewCategory
{
    [Inject]
    public ICategoryService CategoryService { get; set; }
    [Inject]
    public IDialogService DialogService { get; set; }

    public IEnumerable<CategoryDto> CategoryDtos { get; set; }

    protected override async Task OnInitializedAsync()
        => CategoryDtos = await CategoryService.GetCategoriesAsync();

    private async Task DeleteCategoryAsync(Guid id)
    {
        var parameters = new DialogParameters();
        parameters.Add($"CategoryId", id);
        var dialog = await DialogService.ShowAsync<DeleteCategoryDialog>("Delete Category", parameters);

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            CategoryDtos = CategoryDtos.Where(x => x.Id != id).ToList();
            StateHasChanged();
        }
    }
}

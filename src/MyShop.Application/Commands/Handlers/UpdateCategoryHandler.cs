using MyShop.Application.Abstractions;
using MyShop.Application.Exceptions;
using MyShop.Core.Repositories;
using MyShop.Core.ValueObjects;

namespace MyShop.Application.Commands.Handlers;

public sealed class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository) 
        => _categoryRepository = categoryRepository;

    public async Task HandleAsync(UpdateCategory command)
    {
        var categoryId = new CategoryId(command.CategoryId);
        var category = await _categoryRepository.GetCategoryAsync(categoryId);
        if (category is null) 
            throw new NotFoundProductException(categoryId);

        category.Update(command.Name);
    }
}

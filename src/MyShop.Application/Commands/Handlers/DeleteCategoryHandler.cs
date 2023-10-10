using MyShop.Application.Abstractions;
using MyShop.Application.Exceptions;
using MyShop.Core.Repositories;
using MyShop.Core.ValueObjects;

namespace MyShop.Application.Commands.Handlers;

public sealed class DeleteCategoryHandler : ICommandHandler<DeleteCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;

    public async Task HandleAsync(DeleteCategory command)
    {
        var categoryId = new CategoryId(command.CategoryId);
        var category = await _categoryRepository.GetCategoryAsync(categoryId);

        if (category is null)
        {
            throw new NotFoundCategoryException(categoryId);
        }

        _categoryRepository.DeleteCategory(category);
    }
}

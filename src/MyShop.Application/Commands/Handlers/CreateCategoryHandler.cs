using MyShop.Application.Abstractions;
using MyShop.Core.Entities;
using MyShop.Core.Repositories;

namespace MyShop.Application.Commands.Handlers;

public sealed class CreateCategoryHandler : ICommandHandler<CreateCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository) 
        => _categoryRepository = categoryRepository;

    public async Task HandleAsync(CreateCategory command)
    {
        var category = Category.Create(command.Name);

        await _categoryRepository.AddCategoryAsync(category);
    }
}

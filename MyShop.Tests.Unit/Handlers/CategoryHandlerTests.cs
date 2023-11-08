using FluentAssertions;
using Moq;
using MyShop.Application.Commands;
using MyShop.Application.Commands.Handlers;
using MyShop.Core.Repositories;
using Xunit;

namespace MyShop.Tests.Unit.Entities;

public class CategoryHandlerTests
{
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock = new Mock<ICategoryRepository>();

    public CategoryHandlerTests()
        => _categoryRepositoryMock = new Mock<ICategoryRepository>();

    [Fact]
    public async Task Should_Return_Fail_Update_Category()
    {
        //Arrange
        var update = new UpdateCategory(Guid.NewGuid(), "Spodnie");
        var updateHandler = new UpdateCategoryHandler(_categoryRepositoryMock.Object);

        //Act
        var exception = await Record.ExceptionAsync(() => updateHandler.HandleAsync(update));

        //Assert
        exception.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_Fail_Delete_Category()
    {
        //Arrange
        var delete = new DeleteCategory(Guid.NewGuid());
        var deleteHandler = new DeleteCategoryHandler(_categoryRepositoryMock.Object);

        //Act
        var exception = await Record.ExceptionAsync(() => deleteHandler.HandleAsync(delete));

        //Assert
        exception.Should().NotBeNull();
    }
}

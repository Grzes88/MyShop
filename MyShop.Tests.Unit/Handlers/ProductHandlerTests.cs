using Moq;
using MyShop.Application.Commands.Handlers;
using MyShop.Application.Commands;
using MyShop.Core.Repositories;
using Xunit;
using FluentAssertions;

namespace MyShop.Tests.Unit.Handlers;

public class ProductHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();

    public ProductHandlerTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
    }

    [Fact]
    public async Task Should_Return_Fail_Update_Product()
    {
        //Arrange
        var update = new UpdateProduct(Guid.NewGuid(), "Pasek", "dobry towar", 30, Guid.NewGuid());
        var updateHandler = new UpdateProductHandler(_productRepositoryMock.Object);

        //Act
        var exception = await Record.ExceptionAsync(() => updateHandler.HandleAsync(update));

        //Assert
        exception.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_Fail_Delete_Product()
    {
        //Arrange
        var delete = new DeleteProduct(Guid.NewGuid());
        var deleteHandler = new DeleteProductHandler(_productRepositoryMock.Object);

        //Act
        var exception = await Record.ExceptionAsync(() => deleteHandler.HandleAsync(delete));

        //Assert
        exception.Should().NotBeNull();
    }
}

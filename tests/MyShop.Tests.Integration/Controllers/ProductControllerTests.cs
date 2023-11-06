using MyShop.Application.Commands;
using MyShop.Application.DTO;
using MyShop.Core.Entities;
using Shouldly;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace MyShop.Tests.Integration.Controllers;

public class ProductControllerTests : ControllerTests, IDisposable
{
    private readonly TestDatabase _testDatabase;

    public ProductControllerTests()
        => _testDatabase = new TestDatabase();

    [Fact]
    public async Task Post_Product_Should_Return_NoContent_204_Status_Code()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "Skóra");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();

        var command = new CreateProduct("Kurtka skórzana", "to dobry produkt", 1000, category.Id);

        //Act
        var response = await HttpClient.PostAsJsonAsync("product", command);

        //Arrange
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Update_Product_Should_Return_NoContent_204_Status_Code()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "Skóra");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();

        var product = new Product(Guid.NewGuid(), "Kurtka skórzana", "to dobry produkt", 101, category.Id);
        await _testDatabase.DbContext.Products.AddAsync(product);
        await _testDatabase.DbContext.SaveChangesAsync();

        var command = new UpdateProduct(product.Id, "Buty skórzane", "to dobry produkt", 300, category.Id);

        //Act
        var response = await HttpClient.PutAsJsonAsync($"product/{command.ProductId}", command);

        //Arrange
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Get_Product_Should_Return_Ok_200_Status_Code_And_Product()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "Skóra");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();

        var product = new Product(Guid.NewGuid(), "Kurtka skórzana", "to dobry produkt", 101, category.Id);
        await _testDatabase.DbContext.Products.AddAsync(product);
        await _testDatabase.DbContext.SaveChangesAsync();

        //Act
        var productDto = await HttpClient.GetFromJsonAsync<ProductDto>($"product/{product.Id.Value}");

        //Arrange
        productDto.ShouldNotBeNull();
        productDto.Id.Equals(product.Id);
    }

    [Fact]
    public async Task Get_Products_Should_Return_Ok_200_Status_Code_And_Products()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "Skóra");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();

        var product = new Product(Guid.NewGuid(), "Kurtka skórzana", "to dobry produkt", 101, category.Id);
        await _testDatabase.DbContext.Products.AddAsync(product);
        await _testDatabase.DbContext.SaveChangesAsync();

        //Act
        var ProductsDto = await HttpClient.GetFromJsonAsync<List<ProductDto>>("categories");

        //Arrange
        ProductsDto.ShouldNotBeNull();
        ProductsDto.Select(x => x.Id == category.Id.Value).ToList();
    }

    [Fact]
    public async Task Delete_Product_Should_Return_NoContent_204_Status_Code()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "spodnie");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();

        var product = new Product(Guid.NewGuid(), "Kurtka skórzana", "to dobry produkt", 101, category.Id);
        await _testDatabase.DbContext.Products.AddAsync(product);
        await _testDatabase.DbContext.SaveChangesAsync();

        //Act
        var response = await HttpClient.DeleteAsync($"product/{product.Id.Value}");

        //Arrange
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }

    public void Dispose()
        => _testDatabase.Dispose();
}

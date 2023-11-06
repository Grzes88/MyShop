using MyShop.Application.Commands;
using MyShop.Application.DTO;
using MyShop.Core.Entities;
using Shouldly;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace MyShop.Tests.Integration.Controllers;

public class CategoryControllerTests : ControllerTests, IDisposable
{
    private readonly TestDatabase _testDatabase;

    public CategoryControllerTests()
        => _testDatabase = new TestDatabase();

    [Fact]
    public async Task Post_Category_Should_Return_NoContent_204_Status_Code()
    {
        //Assert
        var command = new CreateCategory("Buty");

        //Act
        var response = await HttpClient.PostAsJsonAsync("category", command);

        //Arrange
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Update_Category_Should_Return_NoContent_204_Status_Code()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "Pościel");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();
        var command = new UpdateCategory(category.Id, "Spodnie");

        //Act
        var response = await HttpClient.PutAsJsonAsync($"category/{command.CategoryId}", command);

        //Arrange
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Get_Category_Should_Return_Ok_200_Status_Code_And_Category()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "spodnie");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();

        //Act
        var categoryDto = await HttpClient.GetFromJsonAsync<CategoryDto>($"category/{category.Id.Value}");

        //Arrange
        categoryDto.ShouldNotBeNull();
        categoryDto.Id.Equals(category.Id);
    }

    [Fact]
    public async Task Get_Categories_Should_Return_Ok_200_Status_Code_And_Categories()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "spodnie");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();

        //Act
        var categoriesDto = await HttpClient.GetFromJsonAsync<List<CategoryDto>>("categories");

        //Arrange
        categoriesDto.ShouldNotBeNull();
        categoriesDto.Select(x => x.Id == category.Id.Value).ToList();
    }

    [Fact]
    public async Task Delete_Category_Should_Return_NoContent_204_Status_Code()
    {
        //Assert
        var category = new Category(Guid.NewGuid(), "spodnie");
        await _testDatabase.DbContext.Categories.AddAsync(category);
        await _testDatabase.DbContext.SaveChangesAsync();

        //Act
        var response = await HttpClient.DeleteAsync($"category/{category.Id.Value}");

        //Arrange
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }

    public void Dispose()
        => _testDatabase.Dispose();
}

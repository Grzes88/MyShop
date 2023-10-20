using MyShop.Application.DTO;
using MyShop.Core.Entities;
using System.Linq.Expressions;

namespace MyShop.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static Expression<Func<Category, CategoryDto>> AsCategoryDto()
    {
        return c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
        };
    }  
    
    public static Expression<Func<Product, ProductDto>> AsProductDto()
    {
        return c => new ProductDto
        {
            Id = c.Id,
            Name = c.Name,
            Price = c.Price,
            Description = c.Description,
            CategoryId = c.CategoryId,
        };
    }
}
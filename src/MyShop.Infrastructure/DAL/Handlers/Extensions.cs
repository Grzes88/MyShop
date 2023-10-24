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
            Name = c.Name
        };
    } 
    
    public static Expression<Func<Product, ProductDto>> AsProductDto()
    {
        return p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            Category = new CategoryDto { Id = p.Id, Name = p.Name }
        };
    }
}
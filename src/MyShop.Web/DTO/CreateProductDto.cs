﻿namespace MyShop.Web.DTO;

public class CreateProductDto
{
    public string Name { get; }
    public string Description { get; }
    public decimal Price { get; }

    public Guid CategoryId { get; }

    public CreateProductDto(string name, string description, decimal price, Guid categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}

﻿using MyShop.Core.ValueObjects;

namespace MyShop.Core.Entities;

public class Product
{
    public ProductId Id { get; }
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Price Price { get; private set; }

    public CategoryId CategoryId { get; private set; }
    public Category Category { get; private set; }

    private Product()
    {
    }

    public Product(ProductId id, Name name, Description description,
        Price price, Category category)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

    public Product(ProductId id, Name name,
        Description description, Price price, CategoryId categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Price = price;
    }

    public static Product Create(Name name, Description description, Price price, CategoryId categoryId)
        => new(Guid.NewGuid(), name, description, price, categoryId);

    public void Update(Name name, Description description, Price price, CategoryId categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}

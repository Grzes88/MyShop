using MyShop.Core.ValueObjects;

namespace MyShop.Core.Entities;

public class Product
{
    public ProductId Id { get; }
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Price Price { get; set; }

    public CategoryId CategoryId { get; set; }
    public Category Category { get; private set; }

    private Product()
    {
    }

    public Product(ProductId id, Name name,
        Description description, CategoryId categoryId, Price price)
    {
        Id = id;
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Price = price;
    }
}

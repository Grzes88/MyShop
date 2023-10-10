namespace MyShop.Application.DTO;

public class ProductDto
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public double Price { get; }
    public Guid CategoryId { get; }

    public ProductDto(Guid id, string name, string description, double price, Guid categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}

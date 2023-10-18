namespace MyShop.Web.DTO;

public class UpdateProductDto
{
    public string Name { get; }
    public string Description { get; }
    public double Price { get; }

    public Guid CategoryId { get; }

    public UpdateProductDto(string name, string description, double price, Guid categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}

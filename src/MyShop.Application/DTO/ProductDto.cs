namespace MyShop.Application.DTO;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public Guid CategoryId { get; set; }
}

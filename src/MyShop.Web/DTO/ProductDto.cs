namespace MyShop.Web.DTO;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public CategoryDto? Category { get; set; }
}

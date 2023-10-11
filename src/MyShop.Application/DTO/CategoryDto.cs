namespace MyShop.Application.DTO;

public class CategoryDto
{
    public Guid Id { get; }
    public string Name { get; }

    public CategoryDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}

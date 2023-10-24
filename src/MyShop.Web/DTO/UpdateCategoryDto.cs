namespace MyShop.Web.DTO;

public class UpdateCategoryDto
{
    public string? Name { get; }

    public UpdateCategoryDto(string name)
    {
        Name = name;
    }
}

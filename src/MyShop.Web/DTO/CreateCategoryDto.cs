namespace MyShop.Web.DTO;

public class CreateCategoryDto
{
    public string Name { get; }

    public CreateCategoryDto(string name)
    {
        Name = name;
    }
}

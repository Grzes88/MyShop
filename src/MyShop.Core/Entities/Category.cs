using MyShop.Core.ValueObjects;

namespace MyShop.Core.Entities;

public class Category
{
    public CategoryId Id { get; }
    public Name Name { get; private set; }

    public IEnumerable<Product> Products => _products;
    private readonly HashSet<Product> _products = new();

    private Category()
    {
    }

    public Category(CategoryId id, Name name)
    {
        Id = id;
        Name = name;
    }
}

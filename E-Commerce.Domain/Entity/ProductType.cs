namespace E_Commerce.Domain.Entity;

public class ProductType: BaseEntity
{
    public string Name { get; private set; } = null!;

    public ICollection<Product> Products { get; private set; } = [];
}
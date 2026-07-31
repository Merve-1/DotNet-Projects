namespace E_Commerce.Domain.Entity;

public class ProductBrand: BaseEntity
{
    public string Name { get; private set; } = null!;

    public ICollection<Product> Products { get; private set; } = [];
}
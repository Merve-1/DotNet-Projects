namespace E_Commerce.Domain.Entity;

public class Product : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    
    //ToDo: Cloud Storage
    public string PictureUrl { get; private set; }
    
    public decimal Price { get; private set; }
    
    public Guid ProductBrandId { get; set; }
    
    public ProductBrand ProductBrand { get; private set; } = null!;
    
    public Guid ProductTypeId { get; set; }

    public ProductType ProductType { get; private set; } = null!;

}
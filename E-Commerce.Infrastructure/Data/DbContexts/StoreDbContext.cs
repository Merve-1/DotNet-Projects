using E_Commerce.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data.DbContexts;

public class StoreDbContext (DbContextOptions options):DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductBrand> Brands => Set<ProductBrand>();
    public DbSet<ProductType> Types => Set<ProductType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}
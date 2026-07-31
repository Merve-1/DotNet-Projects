using E_Commerce.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration config)
    {
        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging();
        });
        return services;
    }
    
}
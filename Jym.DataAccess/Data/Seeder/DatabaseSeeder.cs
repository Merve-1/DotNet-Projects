using Jym.DataAccess.Data.Contexts;

namespace Jym.DataAccess.Data.Seeder;

public class DatabaseSeeder
{
    public static async Task SeedAllAsync(JymDbContext dbContext)
    {
        await PlanSeeder.SeedAsync(dbContext);
        await CategorySeeder.SeedAsync(dbContext);
        
        
    }
}
using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jym.DataAccess.Data.Seeder;

public static class CategorySeeder
{
    public static async Task SeedAsync(JymDbContext dbContext)
    {
        if (await dbContext.Categories.AnyAsync())
            return;
        var categories = new List<Category>
        {
            new()
            {
                CategoryName = "Yoga"
            },
            new()
            {
                CategoryName = "Cardio"
            },
            new()
            {
                CategoryName = "CrossFit"
            },
            new()
            {
                CategoryName = "Boxing"
            }
        };
        await dbContext.Categories.AddRangeAsync(categories);
        await dbContext.SaveChangesAsync();

    }
}
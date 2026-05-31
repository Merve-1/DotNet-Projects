using GymProject.Data.Contexts;
using GymProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GymProject.Data.Seeder;

public static class PlanSeeder
{
    public static async Task SeedAsync()
    {
        using var dbContext = new JymDbContext();
        
        bool hasAnyPlans = await dbContext.Plans.AnyAsync();

        if (hasAnyPlans)
        {
            return;
        }

        List<Plan> plans =
        [
            new()
            {
                Name = "Basic",
                Description = "Basic gym access",
                DurationDays = 30,
                Price = 300,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            },

            new()
            {
                Name = "Standard",
                Description = "Gym access + group classes",
                DurationDays = 30,
                Price = 500,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            },

            new()
            {
                Name = "Premium",
                Description = "Full access with personal trainer sessions",
                DurationDays = 30,
                Price = 900,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            },

            new()
            {
                Name = "Quarterly",
                Description = "3-month membership plan",
                DurationDays = 90,
                Price = 1200,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            },

            new()
            {
                Name = "Annual",
                Description = "1-year unlimited gym membership",
                DurationDays = 365,
                Price = 4000,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            }
        ];
        await dbContext.Plans.AddRangeAsync(plans);
        
        await dbContext.SaveChangesAsync();
    }
}
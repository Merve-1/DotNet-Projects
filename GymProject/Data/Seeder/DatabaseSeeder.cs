namespace GymProject.Data.Seeder;

public class DatabaseSeeder
{
    public static async Task SeedAllAsync()
    {
        await PlanSeeder.SeedAsync();
        
    }
}
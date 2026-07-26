using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Jym.DataAccess.Data.Repositories;

public class PlanRepository(JymDbContext dbContext): IPlanRepository
{

    public void Add(Plan plan)
        => dbContext.Add(plan);

    public void Delete(Plan plan)
        => dbContext.Remove(plan);

    public async Task<IEnumerable<Plan>> GetAllAsync()
        => await dbContext.Plans.ToListAsync();

    public async Task<Plan?> GetByIdAsync(int id)
        => await dbContext.Plans.FirstOrDefaultAsync(p => p.Id == id);

    public void Update(Plan plan)
        => dbContext.Update(plan);

    public async Task<int> SaveChangesAsync()
        => await dbContext.SaveChangesAsync();
}
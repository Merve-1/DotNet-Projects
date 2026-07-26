using Jym.DataAccess.Models;

namespace Jym.DataAccess.Data.Repositories;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> GetAllAsync();
    
    Task<Plan?> GetByIdAsync(int planId);

    void Add(Plan plan);
    
    void Update(Plan plan);
    
    void Delete(Plan plan);

    Task<int> SaveChangesAsync();

}
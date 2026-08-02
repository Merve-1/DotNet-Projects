using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Models;

namespace Jym.DataAccess.Data.Repositories;



public class PlanRepository(JymDbContext dbContext)
    : Repository<Plan>(dbContext), IPlanRepository
{
    //private readonly JymDbContext _context;
    //public PlanRepository(JymDbContext ctx) => _context = ctx;

    //public IEnumerable<Plan> GetAll() => _context.Plans.ToList();
    //public Plan? GetById(int id) => _context.Plans.Find(id);
    //public void Add(Plan p) => _context.Plans.Add(p);
    //public void Update(Plan p) => _context.Plans.Update(p);
    //public void Delete(Plan p) => _context.Plans.Remove(p);
}
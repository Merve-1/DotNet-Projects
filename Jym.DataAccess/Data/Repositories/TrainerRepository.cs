using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Entities;

namespace Jym.DataAccess.Data.Repositories;

public class TrainerRepository
{
    private readonly JymDbContext _context;
    public TrainerRepository(JymDbContext ctx) => _context = ctx;

    public IEnumerable<Trainer> GetAll() => _context.Trainers.ToList();
    public Trainer? GetById(int id) => _context.Trainers.Find(id);
    public void Add(Trainer t) => _context.Trainers.Add(t);
    public void Update(Trainer t) => _context.Trainers.Update(t);
    public void Delete(Trainer t) => _context.Trainers.Remove(t);
}
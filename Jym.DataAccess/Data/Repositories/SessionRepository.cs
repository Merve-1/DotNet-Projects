using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Entities;

namespace Jym.DataAccess.Data.Repositories;

public class SessionRepository
{
    private readonly JymDbContext _context;
    public SessionRepository(JymDbContext ctx) => _context = ctx;

    public IEnumerable<Session> GetAll() => _context.Sessions.ToList();
    public Session? GetById(int id) => _context.Sessions.Find(id);
    public void Add(Session s) => _context.Sessions.Add(s);
    public void Update(Session s) => _context.Sessions.Update(s);
    public void Delete(Session s) => _context.Sessions.Remove(s);
}
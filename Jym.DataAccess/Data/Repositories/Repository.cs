using System.Linq.Expressions;
using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Data.Repositories;
using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gymy.DataAccess.Repositories;

public class Repository<TEntity>(JymDbContext dbContext) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    
    protected readonly JymDbContext _dbContext = dbContext;
    protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public async Task<TEntity?> GetByIdIncludingDeletedAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(t => t.Id == id, cancellationToken);

    public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.Where(predicate).ToListAsync(cancellationToken);

    // Example usage for a Member query:
    // FindAsync(x => x.Name == "John" && x.Age > 30)

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public Task SoftDeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        // marks entity as deleted rather than physically removing it
        // (exact body was not fully legible in the source video)
        throw new NotImplementedException();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}
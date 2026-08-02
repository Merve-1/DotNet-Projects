using System.Linq.Expressions;
using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jym.DataAccess.Data.Repositories;

public class Repository<TEntity>(JymDbContext dbContext) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly JymDbContext _dbContext = dbContext;
    protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<TEntity>> GetAllIncludingAsync(
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var include in includes)
            query = query.Include(include);

        return await query.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<TEntity?> GetByIdIncludingDeletedAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.Where(predicate).ToListAsync(cancellationToken);

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(predicate, cancellationToken);

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public void Update(TEntity entity)
        => _dbSet.Update(entity);

    public Task SoftDeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}

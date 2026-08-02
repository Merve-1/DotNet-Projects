using System.Linq.Expressions;
using Jym.DataAccess.Entities;

namespace Jym.DataAccess.Data.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TEntity>> GetAllIncludingAsync(
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity?> GetByIdIncludingDeletedAsync(int id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Update(TEntity entity);

    Task SoftDeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
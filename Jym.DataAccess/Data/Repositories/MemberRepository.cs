using Gymy.DataAccess.Repositories;
using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Entities;
using Jym.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Jym.DataAccess.Data.Repositories;

public class MemberRepository(JymDbContext dbContext)
    : Repository<Member>(dbContext), IMemberRepository
{
    public async Task<Member?> GetWithHealthRecordAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(m => m.HealthRecord)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(m => m.Email == email, cancellationToken);

    public async Task<bool> ExistsByPhoneAsync(string phone, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(m => m.Phone == phone, cancellationToken);
}

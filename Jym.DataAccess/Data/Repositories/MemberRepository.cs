using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jym.DataAccess.Data.Repositories;

public class MemberRepository(JymDbContext dbContext)
    : Repository<Member>(dbContext), IMemberRepository
{
    private readonly JymDbContext _dbContext = dbContext;

    public Task<Member?> GetWithMembershipsAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<Member>()
            .Include(m => m.MemberShip)
            .ThenInclude(ms => ms.Plan)
            .Include(m => m.Bookings)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public Task<bool> IsEmailTakenAsync(string normalizedEmail, int? excludeId = null, CancellationToken cancellationToken = default)
        => _dbContext.Set<Member>()
            .AnyAsync(m => m.Email == normalizedEmail && (excludeId == null || m.Id != excludeId), cancellationToken);

    public Task<bool> IsPhoneTakenAsync(string phone, int? excludeId = null, CancellationToken cancellationToken = default)
        => _dbContext.Set<Member>()
            .AnyAsync(m => m.Phone == phone && (excludeId == null || m.Id != excludeId), cancellationToken);

    public Task<bool> HasUpcomingBookingsAsync(int id, CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        return _dbContext.Set<Booking>()
            .AnyAsync(b => b.MemberId == id && b.Session.EndDate >= now, cancellationToken);
    }
}
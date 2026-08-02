using Jym.DataAccess.Entities;

namespace Jym.DataAccess.Data.Repositories;

public interface IMemberRepository : IRepository<Member>
{
    Task<Member?> GetWithMembershipsAsync(int id, CancellationToken cancellationToken = default);

    Task<bool> IsEmailTakenAsync(string normalizedEmail, int? excludeId = null, CancellationToken cancellationToken = default);

    Task<bool> IsPhoneTakenAsync(string phone, int? excludeId = null, CancellationToken cancellationToken = default);

    Task<bool> HasUpcomingBookingsAsync(int id, CancellationToken cancellationToken = default);
}

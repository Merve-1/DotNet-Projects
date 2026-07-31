using Gymy.DataAccess.Repositories;
using Jym.DataAccess.Entities;

namespace Jym.DataAccess.Data.Repositories;

public interface IMemberRepository : IRepository<Member>
{
    Task<Member?> GetWithHealthRecordAsync(int id, CancellationToken cancellationToken = default);

    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<bool> ExistsByPhoneAsync(string phone, CancellationToken cancellationToken = default);
}

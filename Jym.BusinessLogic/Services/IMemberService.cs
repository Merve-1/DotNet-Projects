using Jym.BusinessLogic.Common;
using Jym.BusinessLogic.ViewModels.Members;

namespace Jym.BusinessLogic.Services;

public interface IMemberService
{
    Task<IEnumerable<MemberIndexViewModel>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Result> CreateAsync(CreateMemberViewModel model, CancellationToken cancellationToken = default);
}
using Jym.BusinessLogic.Common;
using Jym.BusinessLogic.ViewModels.HealthRecords;
using Jym.BusinessLogic.ViewModels.Members;

namespace Jym.BusinessLogic.Services;

// Why a service layer instead of calling IMemberRepository straight from the controller?
// 1. Testable business logic without going through an HTTP request.
// 2. The same logic can be reused by both MVC controllers and an API later.
// 3. Computed/derived fields (e.g. formatted display data) don't belong on the DB entity
//    or leak straight into the view -> they belong on a ViewModel built here.

public interface IMemberService
{
    Task<IEnumerable<MemberIndexViewModel>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<MemberDetailsViewModel?> GetDetailsAsync(int id, CancellationToken cancellationToken = default);

    Task<HealthRecordDetailsViewModel?> GetHealthRecordAsync(int id, CancellationToken cancellationToken = default);

    Task<EditMemberViewModel?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(int id, EditMemberViewModel model, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task<Result> CreateAsync(CreateMemberViewModel model, CancellationToken cancellationToken = default);
}
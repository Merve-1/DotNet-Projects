using Jym.BusinessLogic.Common;
using Jym.BusinessLogic.ViewModels.HealthRecords;
using Jym.BusinessLogic.ViewModels.Members;
using Jym.DataAccess.Data.Repositories;
using Jym.DataAccess.Entities;
using Jym.DataAccess.Entities.ValueObjects;
using Jym.DataAccess.Enums;

namespace Jym.BusinessLogic.Services;

public class MemberService(IMemberRepository memberRepository) : IMemberService
{
    public async Task<IEnumerable<MemberIndexViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var members = await memberRepository.GetAllAsync(cancellationToken);

        return members.Select(m => new MemberIndexViewModel
        {
            Id = m.Id,
            Name = m.Name,
            Email = m.Email,
            Phone = m.Phone,
            PhotoUrl = m.Photo,
            JoinDate = m.JoinDate,
            Gender = m.Gender.ToString()
        });
    }

    public async Task<MemberDetailsViewModel?> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        // get member with its membership + plan details
        var member = await memberRepository.GetWithMembershipsAsync(id, cancellationToken);

        if (member is null) return null;

        var activeMembership = member.MemberShip
            .FirstOrDefault(ms => ms.EndDate >= DateTime.Today);

        return new MemberDetailsViewModel
        {
            Id = member.Id,
            Name = member.Name,
            PhotoUrl = member.Photo,
            Email = member.Email,
            Phone = member.Phone,
            Gender = member.Gender.ToString(),
            DateOfBirth = member.DateOfBirth.ToShortDateString(),
            Address = $"{member.Address.BuildingNumber} - {member.Address.Street} - {member.Address.City}",
            PlanName = activeMembership?.Plan.Name ?? "No Active Plan",
            MembershipStartDate = activeMembership?.StartDate.ToShortDateString() ?? "-",
            MembershipEndDate = activeMembership?.EndDate.ToShortDateString() ?? "-"
        };
    }

    public async Task<HealthRecordDetailsViewModel?> GetHealthRecordAsync(int id, CancellationToken cancellationToken = default)
    {
        // reuse the generic GetByIdAsync(...) eager-loading overload instead of adding
        // another one-off repository method just for this.
        var member = await memberRepository.GetByIdAsync(id, cancellationToken, m => m.HealthRecord);

        if (member?.HealthRecord is null) return null;

        return new HealthRecordDetailsViewModel
        {
            Height = member.HealthRecord.Height,
            Weight = member.HealthRecord.Weight,
            BloodType = member.HealthRecord.BloodType.ToString(),
            Note = member.HealthRecord.Notes
        };
    }

    public async Task<EditMemberViewModel?> GetForUpdateAsync(int id, CancellationToken cancellationToken = default)
    {
        var member = await memberRepository.GetByIdAsync(id, cancellationToken);

        if (member is null)
            return null;

        return new EditMemberViewModel
        {
            Id = member.Id,
            Name = member.Name,
            PhotoUrl = member.Photo,
            Email = member.Email,
            Phone = member.Phone,
            BuildingNumber = member.Address.BuildingNumber,
            City = member.Address.City,
            Street = member.Address.Street
        };
    }

    public async Task<Result> UpdateAsync(int id, EditMemberViewModel model, CancellationToken cancellationToken = default)
    {
        var member = await memberRepository.GetByIdAsync(id, cancellationToken);

        if (member is null)
            return Result.Failure("Member not found.", nameof(id));

        // Name is shown read-only in the Edit form on purpose; guard against it being
        // tampered with directly in a raw POST.
        if (member.Name != model.Name)
            return Result.Failure("Name cannot be changed.", nameof(model.Name));

        var normalizedEmail = model.Email.Trim().ToLowerInvariant();
        var normalizedPhone = model.Phone.Trim();

        if (await memberRepository.IsEmailTakenAsync(normalizedEmail, excludeId: id, cancellationToken: cancellationToken))
            return Result.Failure("This email is already registered.", nameof(model.Email));

        if (await memberRepository.IsPhoneTakenAsync(normalizedPhone, excludeId: id, cancellationToken: cancellationToken))
            return Result.Failure("This phone number is already registered.", nameof(model.Phone));

        member.Email = normalizedEmail;
        member.Phone = normalizedPhone;
        member.Address = new Address
        {
            BuildingNumber = model.BuildingNumber,
            City = model.City.Trim(),
            Street = model.Street.Trim()
        };

        await memberRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var member = await memberRepository.GetByIdAsync(id, cancellationToken, m => m.Bookings);

        if (member is null)
            return Result.Failure("Member not found.", nameof(id));

        if (await memberRepository.HasUpcomingBookingsAsync(id, cancellationToken))
            return Result.Failure("Cannot delete member with upcoming bookings.", nameof(id));

        await memberRepository.SoftDeleteAsync(member, cancellationToken);
        await memberRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> CreateAsync(CreateMemberViewModel model, CancellationToken cancellationToken = default)
    {
        // Business rule: Email & Phone must be unique.
        if (await memberRepository.IsEmailTakenAsync(model.Email, cancellationToken: cancellationToken))
            return Result.Failure("This email is already registered.", nameof(model.Email));

        if (await memberRepository.IsPhoneTakenAsync(model.Phone, cancellationToken: cancellationToken))
            return Result.Failure("This phone number is already registered.", nameof(model.Phone));

        if (!Enum.TryParse<BloodType>(model.HealthRecordViewModel.BloodType, out var bloodType))
            return Result.Failure("Invalid blood type.", $"{nameof(model.HealthRecordViewModel)}.{nameof(model.HealthRecordViewModel.BloodType)}");

        var member = new Member
        {
            Name = model.Name,
            Email = model.Email,
            Phone = model.Phone,
            DateOfBirth = model.DateOfBirth,
            Gender = model.Gender,
            // JoinDate is calculated automatically -> not taken as input from the form.
            JoinDate = DateTime.UtcNow,
            Address = new Address
            {
                BuildingNumber = model.BuildingNumber,
                Street = model.Street,
                City = model.City
            },
            HealthRecord = new HealthRecord
            {
                BloodType = bloodType,
                Height = model.HealthRecordViewModel.Height,
                Weight = model.HealthRecordViewModel.Weight,
                Notes = model.HealthRecordViewModel.Note
            }
        };

        await memberRepository.AddAsync(member, cancellationToken);
        await memberRepository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

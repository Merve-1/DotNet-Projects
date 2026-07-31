using Jym.BusinessLogic.Common;
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

    public async Task<Result> CreateAsync(CreateMemberViewModel model, CancellationToken cancellationToken = default)
    {
        // Business rule: Email & Phone must be unique.
        if (await memberRepository.ExistsByEmailAsync(model.Email, cancellationToken))
            return Result.Failure("This email is already registered.", nameof(model.Email));

        if (await memberRepository.ExistsByPhoneAsync(model.Phone, cancellationToken))
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

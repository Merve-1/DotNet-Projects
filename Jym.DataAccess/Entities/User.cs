using Jym.DataAccess.Entities.ValueObjects;
using Jym.DataAccess.Enums;

namespace Jym.DataAccess.Entities;

public abstract class User: BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; } // 0 1
    public Address Address { get; set; } = null!;
}

namespace Jym.BusinessLogic.ViewModels.Members;

public class MemberIndexViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public DateTime? JoinDate { get; set; }

    public string Gender { get; set; } = null!;
}

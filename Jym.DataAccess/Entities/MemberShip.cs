using Jym.DataAccess.Models;

namespace Jym.DataAccess.Entities;

public class MemberShip : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public int MemberId { get; set; }
    public virtual Member Member { get; set; }
    
    public int PlanId  { get; set; }
    public Plan Plan { get; set; } = null!;
}
namespace Jym.DataAccess.Entities;

public class Member : User
{
    public string? Photo { get; set; }    
    
    public DateTime? JoinDate { get; set; }
    
    //HealthRecord 
    public HealthRecord HealthRecord { get; set; } = null!;
    //ICollection<Bookings>
    public ICollection<Booking> Bookings { get; set; } = [];
    //ICollection<MemberShips> 
    public ICollection<MemberShip> MemberShip { get; set; } = [];

}
namespace EventHub.Models;

public class Badge
{
    public int Id { get; set; }
    
    public string BadgeNumber  { get; set; }
    public DateTime IssuedAt { get; set; }
    public String Tier { get; set; }
    
    
    public int AttendeeId { get; set; }
    public Attendee Attendee { get; set; }
}
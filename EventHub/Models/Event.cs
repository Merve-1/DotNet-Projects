namespace EventHub.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public int MaxAttendees { get; set; }
    
    //Organizer
    public int OrganizerId { get; set; }
    public Organizer Organizer { get; set; }
    
    //self reference
    public int? ParentEventId { get; set; }
    public Event ParentEvent { get; set; }
    public List<Event> Sessions { get; set; } = new();

    public List<Registration> Registrations { get; set; } = new();
    
    //hidden
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
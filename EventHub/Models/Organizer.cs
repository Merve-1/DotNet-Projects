using System.ComponentModel.DataAnnotations;

namespace EventHub.Models;

public class Organizer
{
    public int Id { get; set; }
    
    [Required] //Data Annotation 
    public string Name { get; set; }
    
    public string? CompanyName { get; set; }
    
    public bool IsVerified { get; set; }
    
    //1:1
    public OrganizerProfile Profile { get; set; }

    //1:M
    public List<Event> Events { get; set; } = new();
}
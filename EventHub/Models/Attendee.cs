using System.ComponentModel.DataAnnotations;

namespace EventHub.Models;

public class Attendee
{
    public int id { get; set; }
    
    [Required]
    public string FullName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    public Address Address { get; set; } 
    public Badge Badge { get; set; }
    public List<Registration> Registrations { get; set; } = new();
}
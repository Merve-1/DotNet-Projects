using EventHub.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Data;


public class AppDbContext : DbContext
{
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<OrganizerProfile> Profiles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost\\MSSQLSERVER01;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //separate config
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        //owned type
        modelBuilder.Entity<Attendee>().OwnsOne(a => a.Address);
        
        //Organizer => Profile (1:1)
        modelBuilder.Entity<Organizer>()
            .HasOne(o => o.Profile)
            .WithOne(p => p.Organizer)
            .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);
        
        //Badge (1:1)
        modelBuilder.Entity<Attendee>()
            .HasOne(a => a.Badge)
            .WithOne(b => b.Attendee)
            .HasForeignKey<Badge>(b => b.AttendeeId);
        
        //Registration 
        modelBuilder.Entity<Registration>()
            .HasKey(r => new { r.AttendeeId, r.EventId });
        
        //event => session (self reference)
        modelBuilder.Entity<Event>()
            .HasOne(e => e.ParentEvent)
            .WithMany(e => e.Sessions)
            .HasForeignKey(e => e.ParentEventId);
        
        //audit
        modelBuilder.Entity<Event>()
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<Event>()
            .Property(e => e.UpdatedAt)
            .HasDefaultValueSql("GETDATE()");

    }
}
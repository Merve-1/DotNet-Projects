using EventHub.Data;
using EventHub.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHub;

class Program
{
    static void Main(string[] args)
    {   
        /* EventHub is a platform that allows individuals and companies to organize,
           - Organizers can:
                Register with a personal name and optional company name 
                Receive a verified status after review 
                Have a public profile page containing 
                    Biography 
                    Website Link 
                    Logo 
                Profile cannot exist without the organizer account 
            - Organizers can create events with: 
                Title 
                Description 
                Start Date
                Optional end date 
                Maximum attendee limit 
            - Events can contain nested sessions 
                Main event -> Many sessions 
                Each session belongs to only one parent event 
                Self-referencing relationship 
            - Attendees can 
                Register for multiple events 
                Provide
                    Full name 
                    Email 
                    Home Address (Street, City, Country, Postal Code)
            - Badge system
                Issued after attendee registers for at least one event 
                Badge includes 
                    Unique badge number 
                    Issue date 
                    Tier (Standard, VIP)
                    One attendee has at most one badge 
            - Event registration 
                Many attendees can join many events 
                Registration may include 
                    Optional note to organizer 
                    Automatic registration timestamp 
            - Internal event tracking 
                Store creation timestamp 
                Store at last modified timestamp 
                These are internal system fields and not shown publicly 
            - Required Relationships:
                Organizer => Profile (1:1)
                Organizer => Events  (1:Many)
                Event     => Sessions(1:Many) Self
                Attendee  => Event   (Many:Many)
                Attendee  => Badge   (1:1)
                Attendee  => Address Owned Type  
            
        */
        
        
        //Task 
        /*
         * Build full EF core console application 
         * Include
         *  (Entity classes, DbContext, OnModelCreating)
         * Use only one configuration style per entity
         *  (Data Annotations, Fluent API, Separate Configuration Class)
         * 
         */
        
        
        using var context = new AppDbContext();

        context.Database.Migrate();

        Console.WriteLine("Database created successfully!");

        #region Create Organizer

        var organizer = new Organizer
        {
            Name = "Tech Events Group",
            CompanyName = "TEG",
            IsVerified = true,

            Profile = new OrganizerProfile
            {
                Bio = "Leading organizer of technology conferences.",
                Website = "https://techevents.com",
                LogoUrl = "https://techevents.com/logo.png"
            }
        };

        #endregion

        #region Create Event

        var mainEvent = new Event
        {
            Title = "DotNet Conference 2026",
            Description = "Annual conference for .NET developers.",
            StartDate = new DateTime(2026, 7, 10),
            EndDate = new DateTime(2026, 7, 12),
            MaxAttendees = 500,
            Organizer = organizer
        };

        var session = new Event
        {
            Title = "Entity Framework Core Workshop",
            Description = "Deep dive into EF Core.",
            StartDate = new DateTime(2026, 7, 11, 10, 0, 0),
            EndDate = new DateTime(2026, 7, 11, 12, 0, 0),
            MaxAttendees = 100,
            ParentEvent = mainEvent,
            Organizer = organizer
        };

        #endregion

        #region Create Attendee

        var attendee = new Attendee
        {
            FullName = "Ahmed Ali",
            Email = "ahmed@gmail.com",

            Address = new Address
            {
                Street = "15 Main Street",
                City = "Alexandria",
                Country = "Egypt",
                PostalCode = "21500"
            },

            Badge = new Badge
            {
                BadgeNumber = "VIP-1001",
                IssuedAt = DateTime.Now,
                Tier = "VIP"
            }
        };

        #endregion

        #region Registration

        var registration = new Registration
        {
            Attendee = attendee,
            Event = mainEvent,
            Note = "Interested in backend sessions.",
            RegisteredAt = DateTime.Now
        };

        #endregion

        #region Save Data

        context.Registrations.Add(registration);

  
        context.Events.Add(session);

        context.SaveChanges();

        Console.WriteLine("Sample data inserted successfully!");

        #endregion

        #region Retrieve Data

        var events = context.Events
            .Include(e => e.Organizer)
            .Include(e => e.Registrations)
                .ThenInclude(r => r.Attendee)
            .ToList();

        Console.WriteLine("\n===== Events =====\n");

        foreach (var ev in events)
        {
            Console.WriteLine($"Title: {ev.Title}");
            Console.WriteLine($"Organizer: {ev.Organizer.Name}");
            Console.WriteLine($"Max Attendees: {ev.MaxAttendees}");
            Console.WriteLine($"Registrations: {ev.Registrations.Count}");

            foreach (var reg in ev.Registrations)
            {
                Console.WriteLine($" -> Attendee: {reg.Attendee.FullName}");
            }

            Console.WriteLine("-----------------------------------");
        }

        #endregion
    
        
        
    }
}
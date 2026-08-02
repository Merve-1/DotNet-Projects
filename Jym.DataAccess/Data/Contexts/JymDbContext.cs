using Jym.DataAccess.Entities;
using Jym.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Jym.DataAccess.Data.Contexts;

public class JymDbContext: DbContext
{
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer(
//           "Server=localhost\\MSSQLSERVER01;Database=JYM;Trusted_Connection=True;TrustServerCertificate=True");
//    }
    public JymDbContext(DbContextOptions<JymDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JymDbContext).Assembly);
        //modelBuilder.Entity<User>().HasDiscriminator<string>("UserType")
        //   .HasValue<Member>("Member")
        //    .HasValue<Trainer>("Trainer");
        
        //modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);

    }
    
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Member> Members => Set<Member>();
    
    public DbSet<Trainer> Trainers => Set<Trainer>();
    
    public DbSet<Session> Sessions { get; set; }
    
    public DbSet<MemberShip> MemberShips { get; set; }
    
    public DbSet<Booking> Bookings { get; set; }
    
    public DbSet<HealthRecord> HealthRecords { get; set; }
    
    
}

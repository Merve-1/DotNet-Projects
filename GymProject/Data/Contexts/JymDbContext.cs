using GymProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GymProject.Data.Contexts;

public class JymDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost\\MSSQLSERVER01;Database=JYM;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JymDbContext).Assembly);
    }
    public DbSet<Plan> Plans { get; set; }
}
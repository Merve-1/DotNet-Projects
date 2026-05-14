using EF_Core_Assignment01.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost\\MSSQLSERVER01;Database=ReadMoreBooksDB;Trusted_Connection=True;TrustServerCertificate=True");
        
    }
}
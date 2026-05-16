using BankSystem.Models;
using BankSystem.Seed;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Data;

public class BankDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost\\MSSQLSERVER01;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Branch>()
            .HasKey(b => b.Code);

        modelBuilder.Entity<Account>()
            .HasKey(a => a.AccountNumber);

        modelBuilder.Entity<Transaction>()
            .HasKey(t => t.TransactionNumber);

        modelBuilder.Entity<CustomerAccount>()
            .HasKey(ca => new { ca.CustomerId, ca.AccountNumber });

        modelBuilder.Entity<Branch>()
            .HasOne(b => b.Manager)
            .WithOne(m => m.Branch)
            .HasForeignKey<Branch>(b => b.ManagerId);

        modelBuilder.Entity<Branch>()
            .HasMany(b => b.Accounts)
            .WithOne(a => a.Branch)
            .HasForeignKey(a => a.BranchCode);

        modelBuilder.Entity<CustomerAccount>()
            .HasOne(ca => ca.Customer)
            .WithMany(c => c.CustomerAccounts)
            .HasForeignKey(ca => ca.CustomerId);

        modelBuilder.Entity<CustomerAccount>()
            .HasOne(ca => ca.Account)
            .WithMany(a => a.CustomerAccounts)
            .HasForeignKey(ca => ca.AccountNumber);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Account)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AccountNumber);

        SeedData.Seed(modelBuilder);
    }

 

}
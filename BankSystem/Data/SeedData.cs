using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Seed;

public class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manager>().HasData(

            new Manager
            {
                Id = 1,
                FullName = "Ahmed Hassan",
                Email = "ahmed@bank.com",
                PhoneNumber = "+359888888888",
                HireDate = new DateTime(2020, 1, 15)
            },

            new Manager
            {
                Id = 2,
                FullName = "Sara Hassan",
                Email = "sara@bank.com",
                PhoneNumber = "+359888898888",
                HireDate = new DateTime(2020, 1, 10)
            }

        );
        modelBuilder.Entity<Branch>().HasData(

            new Branch
            {
                Code = "BR001",
                Name = "Cairo Branch",
                Address = "Nasr City",
                PhoneNumber = "02222222",
                ManagerId = 1
            },

            new Branch
            {
                Code = "BR002",
                Name = "Alex Branch",
                Address = "Smouha",
                PhoneNumber = "03333333",
                ManagerId = 2
            }

        );
        modelBuilder.Entity<Customer>().HasData(

            new Customer
            {
                Id = 1,
                FullName = "Mohamed Ali",
                DateOfBirth = new DateTime(1995, 5, 10),
                NationalId = "29805151234567",
                Email = "mohamed@gmail.com",
                PhoneNumber = "01011111111",
                Address = "Cairo",
                CustomerType = "Individual"
            },

            new Customer
            {
                Id = 2,
                FullName = "Sara Ahmed",
                DateOfBirth = new DateTime(1992, 8, 20),
                NationalId = "29208201234567",
                Email = "sara@gmail.com",
                PhoneNumber = "01022222222",
                Address = "Alexandria",
                CustomerType = "Business"
            }

        );
        modelBuilder.Entity<Account>().HasData(

            new Account
            {
                AccountNumber = "ACC001",
                AccountType = "Savings",
                OpeningDate = new DateTime(2024, 1, 1),
                CurrentBalance = 5000,
                BranchCode = "BR001"
            },

            new Account
            {
                AccountNumber = "ACC002",
                AccountType = "Current",
                OpeningDate = new DateTime(2024, 2, 1),
                CurrentBalance = 10000,
                BranchCode = "BR002"
            }

        );
        modelBuilder.Entity<CustomerAccount>().HasData(

            new CustomerAccount
            {
                CustomerId = 1,
                AccountNumber = "ACC001",
                OwnershipStartDate = new DateTime(2024, 1, 1),
                OwnershipType = "Primary",
                AccountStatus = "Active"
            },

            new CustomerAccount
            {
                CustomerId = 2,
                AccountNumber = "ACC002",
                OwnershipStartDate = new DateTime(2024, 2, 1),
                OwnershipType = "Primary",
                AccountStatus = "Active"
            }

        );
        modelBuilder.Entity<Transaction>().HasData(

            new Transaction
            {
                TransactionNumber = "TR001",
                TransactionDate = new DateTime(2024, 3, 1),
                Amount = 2000,
                TransactionType = "Deposit",
                Note = "Initial Deposit",
                AccountNumber = "ACC001"
            },

            new Transaction
            {
                TransactionNumber = "TR002",
                TransactionDate = new DateTime(2024, 3, 5),
                Amount = 500,
                TransactionType = "Withdrawal",
                Note = "ATM Withdrawal",
                AccountNumber = "ACC002"
            }

        );
    }
}
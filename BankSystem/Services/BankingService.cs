using BankSystem.Data;
using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Services;

public class BankingService
{
    public BankDbContext _context;

    public BankingService(BankDbContext context)
    {
        _context = context;
    }

    public void AddCustomer()
    {
        Console.Clear();

        Console.WriteLine("=== Add New Customer ===");

        Console.Write("Full Name: ");
        string fullName = Console.ReadLine()!;

        Console.Write("National ID: ");
        string nationalId = Console.ReadLine()!;

        DateTime dob;
        Console.Write("Date Of Birth (yyyy-mm-dd): ");

        while (!DateTime.TryParse(Console.ReadLine(), out dob))
        {
            Console.Write("Invalid Date. Try Again: ");
        }

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Phone Number: ");
        string phone = Console.ReadLine()!;

        Console.Write("Address: ");
        string address = Console.ReadLine()!;

        Console.WriteLine("Customer Type:");
        Console.WriteLine("     1) Individual");
        Console.WriteLine("     2) Business");
        Console.Write("  Choice:");
        
        string value = Console.ReadLine()!;
        string customerType;
        if (value == "1")
        {
            customerType = "Individual";
        }
        else if (value =="2")
        {
            customerType = "Business";
        }
        else
        {
            customerType = "Invalid";
        }
        Customer customer = new Customer
        {
            FullName = fullName,
            NationalId = nationalId,
            DateOfBirth = dob,
            Email = email,
            PhoneNumber = phone,
            Address = address,
            CustomerType = customerType
        };

        _context.Customers.Add(customer);

        _context.SaveChanges();

        Console.WriteLine("Customer Added Successfully.");
    }

    public void OpenAccount()
    {
        Console.Clear();

        Console.WriteLine("=== Open New Account ===");

        Console.Write("Account Number: ");
        string accountNumber = Console.ReadLine()!;

        Console.Write("Account Type: ");
        string accountType = Console.ReadLine()!;

        Console.Write("Branch Code: ");
        string branchCode = Console.ReadLine()!;

        // Verify Branch Exists
        var branch = _context.Branches
            .FirstOrDefault(b => b.Code == branchCode);

        if (branch == null)
        {
            Console.WriteLine("Branch Does Not Exist.");
            return;
        }

        int customerId;

        Console.Write("Customer ID: ");

        while (!int.TryParse(Console.ReadLine(), out customerId))
        {
            Console.Write("Invalid ID. Try Again: ");
        }

        // Verify Customer Exists
        var customer = _context.Customers
            .FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            Console.WriteLine("Customer Does Not Exist.");
            return;
        }

        Console.Write("Ownership Type (Primary / CoHolder): ");
        string ownershipType = Console.ReadLine()!;

        Account account = new Account
        {
            AccountNumber = accountNumber,
            AccountType = accountType,
            OpeningDate = DateTime.Now,
            CurrentBalance = 0,
            BranchCode = branchCode
        };

        _context.Accounts.Add(account);

        CustomerAccount customerAccount = new CustomerAccount
        {
            CustomerId = customerId,
            AccountNumber = accountNumber,
            OwnershipStartDate = DateTime.Now,
            OwnershipType = ownershipType,
            AccountStatus = "Active"
        };

        _context.CustomerAccounts.Add(customerAccount);

        _context.SaveChanges();

        Console.WriteLine("Account Opened Successfully.");
    }


    public void UpdateAccountStatus()
    {
        Console.Clear();

        Console.WriteLine("=== Update Account Status ===");

        Console.Write("Account Number: ");
        string accountNumber = Console.ReadLine()!;

        int customerId;

        Console.Write("Customer ID: ");

        while (!int.TryParse(Console.ReadLine(), out customerId))
        {
            Console.Write("Invalid ID. Try Again: ");
        }

        var customerAccount = _context.CustomerAccounts
            .FirstOrDefault(ca =>
                ca.AccountNumber == accountNumber &&
                ca.CustomerId == customerId);

        if (customerAccount == null)
        {
            Console.WriteLine("Customer Account Not Found.");
            return;
        }

        customerAccount.AccountStatus =
            customerAccount.AccountStatus == "Active"
                ? "Closed"
                : "Active";

        _context.SaveChanges();

        Console.WriteLine("Account Status Updated Successfully.");
    }

    public void RemoveAccountFromCustomer()
    {
        Console.Clear();

        Console.WriteLine("=== Remove Customer From Customer ===");

        Console.Write("Account Number: ");

        string accountNumber = Console.ReadLine()!;

        int customerId;
        Console.Write("Customer ID: ");
        while (!int.TryParse(Console.ReadLine(), out customerId))
        {
            Console.WriteLine("Invalid Id. Try Again: ");
        }

        var customerAccount = _context.CustomerAccounts
            .FirstOrDefault(ca =>
                ca.AccountNumber == accountNumber && ca.CustomerId == customerId);

        if (customerAccount == null)
        {
            Console.WriteLine("Customer Account Not Found.");
            return;

        }

        _context.CustomerAccounts.Remove(customerAccount);
        _context.SaveChanges();
        Console.WriteLine("Customer Removed Successfully.");


    }

    public void ListCustomers()
    {
        Console.Clear();

        Console.WriteLine("=== Customers List ===");

        var customers = _context.Customers
            .Include(c => c.CustomerAccounts)
            .ThenInclude(ca => ca.Account)
            .ToList();

        foreach (var customer in customers)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Customer ID: {customer.Id}");
            Console.WriteLine($"Name: {customer.FullName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.PhoneNumber}");
            Console.WriteLine($"Type: {customer.CustomerType}");

            Console.WriteLine("Accounts:");

            foreach (var customerAccount in customer.CustomerAccounts)
            {
                Console.WriteLine($"   Account Number: {customerAccount.Account.AccountNumber}");
                Console.WriteLine($"   Type: {customerAccount.Account.AccountType}");
                Console.WriteLine($"   Balance: {customerAccount.Account.CurrentBalance}");
                Console.WriteLine($"   Status: {customerAccount.AccountStatus}");
                Console.WriteLine();
            }
        }
    }
}


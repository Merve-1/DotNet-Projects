using BankSystem.Data;
using BankSystem.Services;

namespace BankSystem;

class Program
{
    static void Main(string[] args)
    {
        using BankDbContext context = new BankDbContext();
        BankingService service = new BankingService(context);

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("     National Bank - Management ");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Add a New Customer");
            Console.WriteLine("2. Open a new Account for a Customer");
            Console.WriteLine("3. Update Account Status (Active/ Closed)");
            Console.WriteLine("4. Remove an Account From a Customer");
            Console.WriteLine("5. List All Customers (with accounts)");
            Console.WriteLine("0. Exit");
            Console.WriteLine("===================================");

            Console.Write("Enter choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    service.AddCustomer();
                    break;
                case "2":
                    service.OpenAccount();
                    break;
                case "3":
                    service.UpdateAccountStatus();
                    break;
                case "4":
                    service.RemoveAccountFromCustomer();
                    break;
                case "5":
                    service.ListCustomers();
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Closing system...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
            }
        
       }
    }
}
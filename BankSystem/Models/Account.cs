namespace BankSystem.Models;

public class Account
{
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public DateTime OpeningDate { get; set; }
    public decimal CurrentBalance { get; set; }
    
    public string BranchCode { get; set; }
    public Branch Branch { get; set; }
    
    public ICollection<CustomerAccount> CustomerAccounts { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    
}
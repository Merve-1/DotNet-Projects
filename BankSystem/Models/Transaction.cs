namespace BankSystem.Models;

public class Transaction
{
    public string TransactionNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }
    public string Note { get; set; }
    
    public string AccountNumber { get; set; }
    public Account Account { get; set; }
}
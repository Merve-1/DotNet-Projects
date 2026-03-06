namespace Assignment_04;

public class VIPTicket : Ticket
{
    public bool LoungeAccess { get; set; }
    public decimal ServiceFee { get; } = 50;

    public VIPTicket(string movie, decimal price, bool lounge)
        : base(movie, price + 50)
    {
        LoungeAccess = lounge;
    }

    public override void PrintTicket()
    {
        base.PrintTicket();
        Console.WriteLine($"      Lounge: {(LoungeAccess ? "yes": "no")} | Service Fee: {ServiceFee} EGP");
    }

}
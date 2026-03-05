namespace ConsoleApp1;

public class VIPTicket: Ticket
{
    public bool LoungeAccess { get; set; }
    public decimal ServiceFee { get; } = 50m;

    public VIPTicket(string movieName, decimal price, bool loungeAccess)
        : base(movieName, price)
    {
        LoungeAccess = loungeAccess;
    }

    public override string ToString()
    {
        return base.ToString() + 
               $" Lounge: {(LoungeAccess ? "Yes" : "No")} | Service Fee: {ServiceFee} EGP";    }
}
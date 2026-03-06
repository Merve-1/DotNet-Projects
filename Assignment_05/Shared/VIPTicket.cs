using Assignment_05.Implementation;

public class VIPTicket: Ticket
{
    public bool LoungeAccess { get; set; }
    public double VipFee { get; set; }

    public VIPTicket(string movie, double price, bool lounge, double fee)
        : base(movie, price)
    {
        LoungeAccess = lounge;
        VipFee = fee;
        
    }
    public override void Print()
    {
        Console.WriteLine($"[Ticket #{TicketNumber}] {MovieName} | VIP | Lounge: {(LoungeAccess? "Yes": "No")} | Fee: {VipFee} | Price: {Price} | After Tax: {PriceAfterTax():F1} | Booked: {(IsBooked? "Yes": "No")}");
    }

    public override object Clone()
    {
        VIPTicket clone = (VIPTicket)this.MemberwiseClone();
        clone.TicketNumber = new Random().Next(10, 99);
        clone.Cancel();
        return clone;
    }
}
namespace Assignment_06.TicketTypes;

public class VIPTicket: Ticket
{
    public bool LoungeAccess { get; set; }
    public double Fee { get; set; }

    public VIPTicket(string movie, double price, bool lounge, double fee)
        : base(movie, price)
    {
        LoungeAccess = lounge;
        Fee = fee;
    }

    public override double FinalPrice()
    {
        return (Price * 1.14) + Fee;
    }

    public override void Print()
    {
        Console.WriteLine(
            $"[Ticket #{TicketNumber}] {MovieName} | VIP | Lounge: {(LoungeAccess ? "Yes": "No")} | Fee: {Fee} | Price: {Price} | Final: {FinalPrice():F2} | Booked: {(IsBooked? "Yes" : "No")}");
    }
}
using Assignment_05.Implementation;

namespace Assignment_05.Shared;

public class IMAXTicket: Ticket
{
    public bool Is3D { get; set; }

    public IMAXTicket(string movie, double price, bool is3D)
        : base(movie, price)
    {
        Is3D = is3D;
    }
    public override void Print()
    {
        Console.WriteLine($"[Ticket #{TicketNumber}] {MovieName} | IMAX | 3D: {(Is3D ? "Yes" : "No")} | Price: {Price} | After Tax: {PriceAfterTax():F1} | Booked: {(IsBooked? "Yes": "No")}");
    }

    public override object Clone()
    {
        IMAXTicket clone = (IMAXTicket)this.MemberwiseClone();
        clone.TicketNumber = new Random().Next(10, 99);
        return clone;
    }
    
}
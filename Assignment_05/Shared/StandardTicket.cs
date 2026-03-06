using Assignment_05.Implementation;

public class StandardTicket : Ticket
{
    public string Seat { get; set; }
    public StandardTicket(string movie, double price, string seat) 
        : base(movie, price)
    {
        Seat =  seat;
    }

    public override void Print()
    {
        Console.WriteLine($"[Ticket #{TicketNumber}] {MovieName} | Standard | Seat: {Seat} | Price: {Price} | After Tax: {PriceAfterTax():F1} | Booked: {(IsBooked? "Yes": "No")}");
    }

    public override object Clone()
    {
        StandardTicket clone = (StandardTicket)this.MemberwiseClone();
        clone.TicketNumber = new Random().Next(10, 99);
        return clone;
    }
}
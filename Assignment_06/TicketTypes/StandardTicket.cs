namespace Assignment_06.TicketTypes;

public class StandardTicket: Ticket
{
    public string Seat { get; set; }

    public StandardTicket(string movie, double price, string seat)
        : base(movie, price)
    {
        Seat = seat;
    }

    public override double FinalPrice()
    {
        return Price * 1.14;
    }

    public override void Print()
    {
        Console.WriteLine(
            $"[Ticket #{TicketNumber}] {MovieName} | Standard | Seat: {Seat} | Price: {Price} | Final: {FinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}");
    }
}

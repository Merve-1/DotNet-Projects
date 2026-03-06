namespace Assignment_04;

public class StandardTicket : Ticket
{
    public string SeatNumber { get; set; }

    public StandardTicket(string movie, decimal price, string seat)
        : base(movie, price)
    {
        SeatNumber = seat;
    }

    public override void PrintTicket()
    {
        base.PrintTicket();
        Console.WriteLine($"      Seat: {SeatNumber}");
    }
    
}

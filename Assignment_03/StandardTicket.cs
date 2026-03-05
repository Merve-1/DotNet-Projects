namespace ConsoleApp1;

public class StandardTicket : Ticket
{
    public string SeatNumber { get; set; }
    
    public StandardTicket(string movieName, decimal price, string seatNumber) 
        : base(movieName, price)
    {
        SeatNumber = seatNumber;
    }
    

    public override string ToString()
    {
        return base.ToString() + $" Seat: {SeatNumber}";
    }
}
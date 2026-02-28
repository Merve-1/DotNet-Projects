namespace Assignment_02;

public enum TicketType
{
    Standard, VIP, IMAX
}

public struct SeatLocation
{
    public char Row { get; set; }
    public int Number { get; set; }

    public override string ToString()
    {
        return $"{Row}-{Number}";
    }
}

public class Ticket
{
    private static int ticketCounter = 0;
    private string movieName;
    private double price;
    
    public int TicketId { get; }

    public string MovieName
    {
        get => movieName;
        set
        {
            if (!string.IsNullOrEmpty(value)) movieName = value;
        }
    }
    public TicketType Type { get; set; }
    public SeatLocation Seat { get; set; }

    public double Price
    {
        get => price;
        set
        {
            if (value > 0) price = value;
        }
    }

    public double PriceAfterTax
    {
        get => price* 1.14;
    }

    public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
    {
        TicketId = ++ticketCounter;
        MovieName = movieName;
        Type = type;
        Seat = seat;
        Price = price;
    }

    public static int GetTotalTicketSold()
    {
        return ticketCounter;
    }


}
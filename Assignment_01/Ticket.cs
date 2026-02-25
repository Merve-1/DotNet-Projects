namespace Assignment_01;

public enum TicketType
{
    Standard = 0,
    VIP, 
    IMAX
}

public struct Seat
{
    public char Row;
    public int Number;

    public Seat(char row, int number)
    {
        Row = row;
        Number = number;
    }

    public override string ToString()
    {
        return $"{Row}{Number}";
    }

}
public class Ticket
{
    public String MovieName;
    public TicketType Type;
    public Seat Seat;

    private double Price;

    public Ticket(String movieName, TicketType type, Seat seat, double price)
    {
        MovieName = movieName;
        Type = type;
        Seat = seat;
        Price = price;

    }

    public Ticket(string movieName): this 
        (movieName, TicketType.Standard, new Seat('A', 1), 50)
    {
        
    }
    public double GetPrice()
    {
        return Price;
    }

    public double CalcTotal()
    {
        return Price + (Price * 14/100);
    }

    public void ApplyDiscount(ref double discount)
    {
        if (discount > 0 && discount <= Price)
        {
            Price -= discount;
            discount = 0;
        }
    }

   
}
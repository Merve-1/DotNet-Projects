using Assignment_05.Interfaces;

namespace Assignment_05.Implementation;

public abstract class Ticket: IPrintable, IBookable, ICloneable
{
    private static int _counter = 0;
    
    public int TicketNumber { get; set; }
    public string MovieName { get; set; }
    public double Price { get; set; }

    public bool IsBooked { get; private set; }

    protected Ticket(string movie, double price)
    {
        TicketNumber = ++_counter;
        MovieName = movie;
        Price = price;
    }

    public double PriceAfterTax()
    {
        return Price * 1.14;
    }

    public bool Book()
    {
        if (IsBooked)
        {
            Console.WriteLine($"Ticket #{TicketNumber} already booked.");
            return false;
        }
        IsBooked = true;
        return true;
    }

    public bool Cancel()
    {
        if (!IsBooked)
        {
            Console.WriteLine($"Ticket #{TicketNumber} is not booked.");
            return false;
        }
        IsBooked = false;
        return true;
        
    }
    public abstract void  Print();
    public abstract object Clone();

}
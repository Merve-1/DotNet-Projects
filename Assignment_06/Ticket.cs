namespace Assignment_06;

public abstract class Ticket
{
    private static int _counter = 1;
    public int TicketNumber { get; }
    public string MovieName { get; set; }
    public double Price { get; set; }
    public bool IsBooked { get; private set; }

    protected Ticket(string movie, double price)
    {
        TicketNumber = _counter++;
        MovieName = movie;
        Price = price;
    }

    public abstract double FinalPrice();

    public virtual string Status()
    {
        return IsBooked ? "Booked" : "Not Booked";
    }

    public void Book()
    {
        IsBooked = true;
    }

    public void Cancel()
    {
        IsBooked = false;
    }

    public virtual void Print()
    {
        Console.WriteLine(
            $"[Ticket #{TicketNumber}] {MovieName} |Price: {Price} | Final: {FinalPrice():F2} Booked: {(IsBooked? "Yes": "No")}]");
    }
}
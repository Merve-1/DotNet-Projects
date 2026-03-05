namespace ConsoleApp1;

public class Ticket
{
    private static int _counter = 0;
    public int TicketId { get; }
    public string MovieName { get; set; }
    private decimal _price;

    public decimal Price
    {
        get => _price;
        protected set
        {
            if (value > 0)
                _price = value;
        }
    }

    public decimal PriceAfterTax
    {
        get { return Price * 1.14m; } // 14% tax
    }
    protected Ticket(string movieName, decimal _price)
    {
        _counter++;
        TicketId = _counter;        
        MovieName = movieName;
        Price = _price;
    }
    public virtual void PrintTicket()
    {
        Console.Write(
            $"Ticket #{TicketId} | {MovieName} | Price: {Price:F2} EGP | After Tax: {PriceAfterTax:F2} EGP"
        );
    }

    public static int GetTotalTickets()
    {
        return _counter;
        
    }
    public override string ToString()
    {
        return $"Ticket #{TicketId} | {MovieName} | Price: {Price} EGP | After Tax: {PriceAfterTax:F2} EGP";
    }

 
}
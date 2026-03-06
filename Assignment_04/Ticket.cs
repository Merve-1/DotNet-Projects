namespace Assignment_04;

public abstract class Ticket
{
    private static int _counter = 0;
    
    public int TicketId { get; }
    public string MovieName { get; set; }

    protected decimal _price;

    public decimal Price
    {
        get => _price;
        protected set
        {
            if (value > 0)
                _price = value;
        }
    }

    public decimal PriceAfterTax => Price * 1.14m;

    protected Ticket(string movieName, decimal _price)
    {
        TicketId = ++_counter;
        MovieName = movieName;
        Price  = _price;
    }
    
    //Polymorphic method 
    public virtual void PrintTicket()
    {
        Console.WriteLine($"Ticket#{TicketId} | {MovieName} | Price: {Price} EGP| After Tax: {PriceAfterTax:F2}EGP");
    }
    
    //Method Overloading 
    public void SetPrice(decimal newPrice)
    {
        Price = newPrice;
    }

    public void SetPrice(decimal basePrice, decimal multiplier)
    {
        Price = basePrice * multiplier;
    }

   
}
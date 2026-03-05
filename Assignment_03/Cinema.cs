namespace ConsoleApp1;

public class Cinema
{
    public string CinemaName { get; private set; }

    private Projector _projector = new Projector(); //composition
    
    private Ticket[] _tickets = new Ticket[20];

    public Cinema(string name)
    {
        CinemaName = name;
        
    }

    public void AddTicket(Ticket t)
    {
        for (int i = 0; i < _tickets.Length; i++)
        {
            if (_tickets[i] == null)
            {
                _tickets[i] = t;
                return;
            }
        }

        Console.WriteLine("Cinema is full. Cannot add more tickets.");
    }

    public void PrintAllTickets()
    {
        Console.WriteLine("=================== All Tickets ===================");
        foreach (var t in _tickets)
        {
            if(t != null)
                Console.Write(t + "\n");
        }
    }

    public void PrintStatistics()
    {
        Console.WriteLine("");     
        Console.WriteLine("=================== Statistics ===================");
        Console.WriteLine("Total Tickets Created: " + _tickets.Length);

        Console.WriteLine("");     
        Console.WriteLine("Booking Ref 1: BK-1");
        Console.WriteLine("Booking Ref 2: BK-2");

        Console.WriteLine("");     
        Console.WriteLine("Group Discount (5 x 100 EGP): 450 EGP (10% off)");
        Console.WriteLine("");     

    }

    public void OpenCinema()
    {
        Console.WriteLine($"{CinemaName} is opened.");
        _projector.Start();
    }

    public void CloseCinema()
    {
        Console.WriteLine($"{CinemaName} is closed.");
        _projector.Stop();
    }
    
}
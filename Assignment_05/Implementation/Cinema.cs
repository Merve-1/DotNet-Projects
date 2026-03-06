using Assignment_05.Interfaces;

namespace Assignment_05.Implementation;

public class Cinema
{
    private List<IPrintable> _tickets = new List<IPrintable>();

    public void Open()
    {
        Console.WriteLine("====== Cinema Opened ======");
    }

    public void Close()
    {
        Console.WriteLine("====== Cinema Closed ======");
    }

    public void AddTicket(IPrintable ticket)
    {
        _tickets.Add(ticket);
    }

    public void PrintTickets()
    {
        Console.WriteLine("--- All Tickets ---");
        foreach (var ticket in _tickets)
        {
            ticket.Print();
        }

        Console.WriteLine();
    }
    
}
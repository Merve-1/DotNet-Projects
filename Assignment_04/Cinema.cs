namespace Assignment_04;

public class Cinema
{
    private Ticket[] _tickets = new Ticket[10];
    private Projector _projector = new Projector();

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
    }

    public void PrintAllTickets()
    {
        Console.WriteLine("\n======================== All tickets ========================");
        foreach (var t in _tickets)
        {
            if(t != null)
                t.PrintTicket();
        }
    }
    public void OpenCinema()
    {
        Console.WriteLine("======================== Cinema Opened ========================");
        _projector.Start();
    }

    public void CloseCinema()
    {
        Console.WriteLine("\n======================== Cinema Closed ========================");
        _projector.Stop();
    }
    
}
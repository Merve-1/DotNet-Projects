namespace Assignment_06;

public partial class Cinema
{
    private List<Ticket> _tickets = new List<Ticket>();

    public void Open()
    {
        Console.WriteLine("=== Cinema Opened ===");
    }

    public void Close()
    {
        Console.WriteLine("=== Cinema Closed ===");
    }

    public void AddTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }
}
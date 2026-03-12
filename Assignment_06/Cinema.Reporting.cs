namespace Assignment_06;

public partial class Cinema
{
    public void PrintAllTickets()
    {
        Console.WriteLine("--- All Tickets (From Cinema.Reporting) ---");
        foreach (var t in _tickets)
            t.Print();
    }
}
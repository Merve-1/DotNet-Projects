namespace Assignment_06;

public static class TicketExtensions
{
    public static string GenerateReceipt(this Ticket ticket)
    {
        return
            $@"========== RECEIPT ==========
    Movie        : {ticket.MovieName}
    Price        : {ticket.Price}
    Final        : {ticket.FinalPrice():F2}
    Status       : {(ticket.Status())}
===============================";
    }

    public static double TotalRevenue(this Ticket[] _tickets)
    {
        double total = 0;
        foreach (var t in _tickets)
        {
            total += t.FinalPrice();
        }
        return total;
        
    }
}
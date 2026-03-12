namespace Assignment_06.TicketTypes;

public class IMAXTicket : Ticket
{
    public bool Is3D { get; set; }

    public IMAXTicket(string movie, double price, bool is3D)
        : base(movie, price)
    {
        Is3D = is3D;
    }

    public override double FinalPrice()
    {
        return Price * 1.14;
    }

    public override void Print()
    {
        Console.WriteLine(
            $"[Ticket #{TicketNumber}] {MovieName} | IMAX | 3D: {(Is3D? "Yes": "No")} | Price: {Price} | Final: {FinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}");
    } 

}
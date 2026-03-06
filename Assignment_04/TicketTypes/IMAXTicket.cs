namespace Assignment_04;

public class IMAXTicket: Ticket
{
    
    public bool Is3D { get; set; }

    public IMAXTicket(string movie, decimal price, bool is3D)
        : base(movie, is3D ? price + 30 : price)
    {
        Is3D = is3D;
    }

    public override void PrintTicket()
    {
        base.PrintTicket();
        Console.WriteLine($"      IMAX 3D: {(Is3D ? "Yes": "No")}");
    }
}
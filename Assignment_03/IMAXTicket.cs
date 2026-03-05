namespace ConsoleApp1;

public class IMAXTicket : Ticket
{
    public bool Is3D { get; set; }
    private decimal _price { get; set; } = 30m;

    public IMAXTicket(string movieName, decimal price, bool is3D)
        : base(movieName, price)
    {
        Is3D = is3D;
     
    }

    public override string ToString()
    {
        return base.ToString() +
               $" IMAX 3D: {(Is3D ? "Yes" : "No")}";

    }
    
}
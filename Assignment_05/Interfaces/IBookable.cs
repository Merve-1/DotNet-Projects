namespace Assignment_05.Interfaces;

public interface IBookable
{
    bool Book();
    bool Cancel();
    bool IsBooked { get; }
}
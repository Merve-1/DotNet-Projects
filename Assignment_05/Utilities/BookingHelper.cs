using Assignment_05.Interfaces;

namespace Assignment_05.Utilities;

public class BookingHelper
{
    public static void PrintAll(IPrintable[] items)
    {
        Console.WriteLine("--- BookingHelper.PrintAll ---");
        foreach (var item in items)
        {
            item.Print();
        }
    }
}
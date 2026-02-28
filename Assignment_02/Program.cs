namespace Assignment_02;

public class Program
{
    static void Main(string[] args)
    {
        #region P1Q1
        /*
         * Convert the following class
         * public class BankAccount{
         *      public string Owner;
         *      public double Balance;
         *      public void Withdraw (double amount){
         *          Balance -= amount;
         *      }
         * }
         * a) Identify at least 2 problems with this design from an encapsulation perspective
         * b) Describe how you would fix this class to follow proper encapsulation principles.
         *    You do not need to write the full code
         * c) Explain why exposing fields directly (as public) is considered a bad practice in OOP 
         */
         //Encapsulation problems, if a class exposes fields like this
         /*
          * a)public string MovieName; public double Price;
          *  issue: no validation anyone can set the value of the price
          *        no control over changes, internal state can be corrupted
          *        cannot add logic later without breaking external code
          * b) fix:
          *  private double price;
          *  public double Price{
          *     get{ return price}
          *     set{
          *         if(value>0) price = value;
          *     }
          *  }
          * c) because they: break encapsulation, allow invalid state,
          *    make future refactoring harder, remove control over data
          *    hide internal state, expose behavior 
          */

        #endregion
        
        #region P1Q2
        /*
         * What is the difference between a field and a proper C#? Can a property contain logic?
         * Given an example of a read-only property that returns a calculated value
         */
        //Field: a variable inside a class ex. private double price;
        //Property: a controlled way to access a field
        //  ex. public double Price { get{return price;} set{price = value;}}
        //Can a property contain logic yes 
        //  ex. public double PriceAfterTax{ get{return price * 1.14;} } read-only calculated property
        #endregion
        
        #region P1Q3
        /*
         * 
         * public class StudentRegister{
         *  private string[] names = new string[5];
         *  public string this [int index]{
         *      get{ return names[index]; }
         *      set{ names[index] = value; }
         *  }
         * }
         *
         *
         * a) what is 'this [int index]' called? explain its purpose
         * b) what happens if someone writes 'register [10] = "Ali";'? How would you make the indexer safer?
         * c) can a class have more than one indexer? if yes, give an example of when that would be useful
         */
        // a) this [int index] it's called an indexer, it allows access like an array register[0] = "Ali";
        // b) register[10] = "Ali"; if internal array size< 11 IndexOutOfRangeException
        //      safer: set {if(index>= 0 && index< names.Length) names[index] = value;}
        // c) can a class have more than one indexer, yes 
        //      ex. public string this[int index] {...}
        //          public string this[string name] {...}
        //      access by id or by name
        
        #endregion
        
        #region P1Q4
        /*
         * public class Order
         * {
         *      public static int TotalOrders= 0;
         *      public string Item;
         *      public Order (string item){
         *          Item = item;
         *          TotalOrders++;
         *      }
         * }
         *
         * a) what does the 'static' keyword mean on 'TotalOrders'? How is it different from the 'Item' field?
         * b) can a static method inside 'Order' access the 'Item' field directly? why or why not?
         * 
         */
         // a) static: belongs to the class itself, not instances
         //    public static int TotalOrders; //all objects share it 
         //    non-static: public string Item; // each object has its own copy 
         // b) can static method access instance field, no, because static method belongs to class,
         //    not a specific object, it doesn't know which object's Item to use 
         /*
          *  Class Item{
          *     public int price;            //instance field
          *     public static int count = 0; //static field
          *
          *     public static void PrintPrice(){
          *         Console.WriteLine(price); //This will cause error
          *     }
          * }
          * Memory
          * Class Area
          * -----------
          * Item
          *     count = 0;
          *     PrintPrice()
          *
          * create objects
          *
          * Item item1 = new Item();
          * item1.price = 100;
          *
          * Item item2 = new Item();
          * item2.price = 200;
          *
          * Memory
          * Class Area
          * -----------
          * Item
          *     count = 0;
          *     PrintPrice()
          *
          * HEAP (Objects)
          * ---------------
          * item1
          *     price = 100
          * item2
          *     price = 200
          *
          * one count but 2 different price values
          * the program knows only printPrice(), but it does not automatically know about item1 and item2
          * the program stuck as it asks which price, the price of item1 or item2 or something else
          *
          * static method: belongs to class, no this reference, cannot access instance fields direct, can access static fields
          * non-static method: belongs to object, has this reference, can access instance fields, can access both 
          */
        
        #endregion
        
        #region P2Q1
        /*
         * Refactor the ticket class to use proper encapsulation:
         * - public properties for each field with the following validation
         * ---> MovieName: cannot be null or empty. if an invalid value is set, keep the previous value
         * ---> Type: use the TicketType enum from previous version of ticketing system
         * ---> Seat: use the SeatLocation struct from previous version of ticketing system
         * ---> Price: must be greater than 0. if an invalid value is set, keep the previous value
         * - add property 'PriceAfterTax' that returns the price with 14% tax included (calculated, not stored)
         */ /////DONE//////
        
        #endregion
        
        #region P2Q2
        /*
         * Add a static field and a static method to the ticket class:
         * ---> Add a 'ticketCounter' field that starts at 0
         * ---> Add a 'TicketId' property. Each ticket gets a unique ID automatically when created
         *      (increment 'ticketCounter' in the constructor and assign it to the ID)
         * ---> Add a 'GetTotalTicketsSold()' method that returns the current value of 'ticketCounter'
         */ /////DONE//////
        #endregion
        
        #region P3Q3
        /*
         * Create a 'Cinema' class that holds up to 20 tickets using a private array.
         * ---> Allow User to get and set tickets by index if the index is out of range,
         *      the getter returns null and the setter does nothing.
         * ---> Allow User to get Movie by movieName that returns the first ticket found matching the
         *      given movie name, or null if not found
         * ---> A method 'AddTicket(Ticket t)' that adds a ticket to the first available (null) slot.
         *      Returns true if added, false if the cinema is full 
         */ /////DONE//////
        #endregion
        
        #region P4Q4
        /*
         * Create a static utility class called 'BookingHelper' with the following static methods:
         * ---> 'double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)' that returns total
         *       price with a 10% discount if the group has 5 or more tickets, otherwise returns the full total
         * ---> 'string GenerateBookingReference()' that returns a unique string each time it is called
         *      (e.g., "BK-1", "BK-2", "BK-3", ...) use a private static counter internally  
         */ /////DONE//////
        #endregion
        
        #region P5Q5
        /*
         * in 'Main' method, build a console application that does the following
         * ---> Ask teh user to enter data for 3 tickets (movie name, ticket type, seat row, seat number, price).
         *      Create each Ticket and add it to the Cinema.
         * ---> Print all 3 tickets (access by index 0,1,2) showing: TicketId, MovieName, Type, Seat, Price, and
         *      PriceAfter Tax
         * ---> Ask the user for a movie name and search for it. Print the result or a "not found" message
         * ---> Print the total tickets sold using the method.
         * ---> Generate and print 2 booking references
         * ---> Calculate and print the group discount for a group of 5 tickets at 80 EGP each of them 
         */ /////DONE//////
        Cinema cinema = new Cinema();
        Console.WriteLine("============= Ticket Booking ============");
        for (int i =0; i < 3; i++)
        {
            Console.WriteLine($"Enter data for Ticket {i+1}");
            Console.Write("Movie Name: ");
            string movie = Console.ReadLine();

            Console.Write("Ticket Type (0=Standard, 1=VIP, 2=IMAX): ");
            TicketType type = (TicketType)int.Parse(Console.ReadLine());
            
            Console.Write("Seat Row (A-Z): ");
            char row = char.Parse(Console.ReadLine());
            
            Console.Write("Seat Number: ");
            int number = int.Parse(Console.ReadLine());
            
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());

            Ticket t = new Ticket(movie, type, new SeatLocation{Row = row, Number = number}, price);
            cinema.AddTicket(t);
            Console.WriteLine(" ");

        }
        
        Console.WriteLine("\n============= All Ticket ============");
        for (int i = 0; i < 3; i++)
        {
            var t = cinema[i];
            if (t != null)
            {
                Console.WriteLine($"Ticket #{t.TicketId} | {t.MovieName} | {t.Type} | {t.Seat} | {t.Price} | AfterTax: {t.PriceAfterTax:F2} EGP");
            }
        }
        
        Console.WriteLine("============= Search by Movie ============");
        Console.Write("Enter movie name to search: ");
        string search = Console.ReadLine();

        var found = cinema.GetMovie(search);
        Console.WriteLine(
            found != null
                ? $"Found: {found.MovieName} | Type: {found.Type} | Seat: {found.Seat} | Price: {found.Price} EGP"
                : "Movie not found"
        );
        
        Console.WriteLine("============= Statistics ============");
        
        Console.WriteLine($"Total Tickets Sold: {Ticket.GetTotalTicketSold()}");
        Console.WriteLine($"Booking Reference 1: {BookingHelper.GenerateBookingReference()}");
        Console.WriteLine($"Booking Reference 2: {BookingHelper.GenerateBookingReference()}");

        Console.WriteLine($"Group Discount (5 tickets x 80): {BookingHelper.CalcGroupDiscount(5,80)} EGP (10% off applied)");
        #endregion
    }
}
namespace Assignment_04;

class Program
{
    static void Main(string[] args)
    {
        #region  P1Q1
        /*
         * What is the difference between static binding and dynamic binding?
         * When does each one happen?
         * Static Binding => Compile time binding, method call is resolved at compile time,
         *                   method overloading, non-virtual methods, static methods
         *                   public void Print() {} -> the compiler decides which method to
         *                   call before the program runs
         * Dynamic Binding => Run time binding, method call is resolved at runtime,
         *                    virtual, override, abstract
         *                    Ticket t = new VIPTicket(); t.PrintTicket(); -> even though variable
         *                    type is Ticket, the VIPTicket version runs, and it supports polymorphism 
         */
        

        #endregion
        
        #region  P1Q2
        /*
         * What is the difference between method overloading and method overriding?
         * Overloading: same method name, different parameters, happens in same class,
         *              compile time binding, no keyword needed
         *
         * Overriding: same method name, same parameters, happens in base + child class,
         *             run time binding, keywords e.g. virtual + override 
         */
        

        #endregion
        
        #region  P1Q3
        /*
         * What keywords are used for Method Overriding? What does each one mean?
         * Virtual: used in base class, allow method to be overriden => public virtual void PrintTicket()
         * Override: used in child class, replaces base implementation => public override void PrintTicket()
         * Abstract: declares method without body, forces child class to implement it 
         * Sealed: prevents further overriding => public sealed void PrintTicket()
         */

        

        #endregion
        
        
        #region  P2Q1
        /*
         * Ticket base class
         * a) Add a PrintTicket() method that prints: TicketId, MovieName, Price, PriceAfterTax.
         *    Child classes should be able to provide their own version of this method
         *
         * b) Add two version of SetPrice method, one that takes a decimal (sets price directly) and one that
         *    takes a decimal base price and a decimal multiplier (set price = base x multiplier)
         */ /////////Done/////////
        

        #endregion
        
        #region  P2Q2
        /*
         * In Each Child Class
         * a) StandardTicket: prints the base ticket info and the SeatNumber
         * b) VIPTicket: prints the base ticket info, LoungeAccess, and ServiceFee
         * c) IMAXTicket: prints the base ticket info and whether it is 3D.
         */ /////////Done/////////
        

        #endregion
        
        #region  P2Q3
        /*
         * Cinema Class
         * update PrintAllTickets() so it loops through the Ticket[] array
         * and calls PrintTickets() on each one.
         */ /////////Done/////////
        

        #endregion
        
        #region  P2Q4
        /*
         * Create a static method ProcessTicket(Ticket t) that takes
         * any Ticket and calls PrintTicket() on it 
         */ /////////Done/////////
        

        #endregion
        
        #region  P2Q5
        /*
         * a) Create a Cinema and open it
         * b) Create one StandardTicket, one VIPTicket, and one IMAXTicket.
         * c) Test both versions of SetPrice on one ticket
         * d) Add all tickets to the Cinema and call PrintAllTickets().
         * e) Call ProcessTicket() with one of the tickets.
         * f) Close the Cinema.
         */ /////////Done/////////
        Cinema cinema = new Cinema();
        cinema.OpenCinema();
        Console.WriteLine("\n======================== setPrice test ========================");

        StandardTicket t1 = new StandardTicket("Inception", 100, "A-5");
        VIPTicket t2 = new VIPTicket("Avengers", 150, true);
        IMAXTicket t3 = new IMAXTicket("Dune", 180, false);

        t1.SetPrice(150);
        Console.WriteLine("Setting Price Directly: 150");
        
        t1.SetPrice(100,1.5m);
        Console.WriteLine("Setting Price with multiplier: 100 x 1.5 = 150");
        
        cinema.AddTicket(t1);
        cinema.AddTicket(t2);
        cinema.AddTicket(t3);
        
        cinema.PrintAllTickets();
        ;
        TicketProcessor.ProcessTicket(t2);
        cinema.CloseCinema();

        #endregion


    }
}
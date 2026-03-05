namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        #region P1Q1
        /*
         *  Identify the type of relationship in each scenario below
         *  (Inheritance, Association, Aggregation, Composition, or Dependency)
         *  a) A University has Departments. If the university is closed, the departments no longer exist
         *  b) A Driver uses a Car. The driver does not own the car
         *  c) A Dog is an Animal
         *  d) A Team has Players. If the team is deleted, the players still exist.
         *  e) A method receives a Logger asa a parameter and calls it inside the method only 
         */
        //Solutions 
        /*
         * a) Composition ==> strong ownership, lifecycle dependency, if university dies, department die
         * b) Association ==> loose relationship, no ownership, both can exist independently
         * c) Inheritance ==> "Is-a" relationship, dog inherits animal behavior
         * d) Aggregation ==> weak ownership, team has players, players exist independently
         * e) Dependency  ==> temporary usage, not stored, only used inside method 
         */
        

        #endregion
        
        #region P1Q2
        /*
         * Access Modifiers
         * a) A parent class has a protected field. Can a child class in a different assembly access it?
         *    What about through an object instance from outside?
         * b) What is the difference between protected internal and private protected?
         * c) What does the sealed keyword do when applied to a class?
         *    What about when applied to a method?
         * d) Can you create an object from a sealed class using new? Why or Why not?
         */
        //Solutions
        /*
         * a) Protected field in different assembly
         *    A child class in a different assembly can access it (if inherited)
         *    It cannot be accessed through an object instance from outside
         *    protected accessible inside derived classes only
         *      Parent class is in Assembly A
         *      Child class is in Assembly B
         *      Child inherits form parent
         *    => Child can access the protected member inside its own code,
         *       external code in assembly B cannot access it
         *    ASSEMBLY A: public class Parent {protected int protectedField =10;}
         *    ASSEMBLY B: public class Child : Parent { public void ShowValue(){ Console.WriteLine(protectedField)}} // allowed
         *    EXTERNAL: Child c = new Child(); c.protectedField; //not-allowed (this is object reference)
         *
         * b) protected internal vs private protected
         *    protected internal: same assembly, derived class (as or condition)
         *    private protected: same assembly, cannot be used in derived class (as and condition)
         * c) sealed Keyword
         *    if applied to class, no class can inherit from it => public sealed class Ticket
         *    if applied to method cannot override it further   => public sealed override void Print()
         *
         * d) object creation from sealed class, yes
         *    MySealedClass obj = new MySealedClass(); //Sealed only prevents inheritance not instantiation
         *      
         */
        

        #endregion
        
        #region P2Q1
        /*
         * Create a base class Ticket with:
         * a) MovieName (string), Price(decimal, must be > 0), TicketId(int, read-only, auto-incremented)
         * b) A constructor that takes movieName and price
         * c) A computed property PriceAfterTax That returns the price with 14% tax
         * d) Override ToString() to return the ticket info
         * e) A static int GetTotalTickets() method that returns the total number of tickets created
         */ /////////Done///////////
        

        #endregion
        
        #region P2Q2
        /*
         * Create 3 child classes that inherit from Ticket:
         * a) StandardTicket: adds SeatNumber(String)
         * b) VIPTicket     : adds LoungeAccess(bool) and ServiceFee(decimal)=50
         * c) IMAXTicket    : adds Is3D(bool). if true, the price increases by 30 EGP
         * each child class should override ToString() to include its own extra info 
         */ /////////Done///////////

        

        #endregion
        #region P2Q3
        /*
         * Create a Cinema class that has a CinemaName, a Projector object
         * (created inside Cinema), and holds up to 20 tickets:
         * a) AddTicket(Ticket t)         : adds a ticket to the first available slot
         * b) PrintAllTickets()           : prints all tickets
         * c) OpenCinema()/ closeCinema() : start/ stop the projector
         */ /////////Done///////////
        

        #endregion
        #region P2Q4
        /*
         * In Main:
         * a) Create a Cinema and open it
         * b) Create one of each ticket type (hardcoded data) and add them to the cinema
         * c) Print all tickets
         * d) Close the Cinema
         */ /////////Done///////////

        Cinema cinema = new Cinema("Grande Cinema");
        
        cinema.OpenCinema();

        Ticket t1 = new StandardTicket("Inception", 120m, "A5");
        Ticket t2 = new VIPTicket("Avengers", 200m, true);
        Ticket t3 = new IMAXTicket("Dune", 180m, false);
        
        cinema.AddTicket(t1);
        cinema.AddTicket(t2);
        cinema.AddTicket(t3);

        Console.WriteLine("");     
        cinema.PrintAllTickets();
        
        cinema.PrintStatistics();
        cinema.CloseCinema();




        #endregion
    }
}
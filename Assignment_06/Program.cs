using Assignment_06.TicketTypes;

namespace Assignment_06;

class Program
{
    static void Main(string[] args)
    {
        #region P1Q1
        /*
         * What is abstraction in OOP? How is it different from encapsulation?
         * Give a real-world example (not from the session) that shows the
         * difference between the two.
         */
        //Solution
        /*
         * Abstraction is the concept of hiding implementation details and exposing
         * only the essential functionality of an object. It focuses on what an object
         * does, not how it does it
         * 
         * => It's implemented using, abstract classes, interfaces
         *
         * a) hides complexity
         * b) focuses on what an object does
         * c) archived using abstract classes and interfaces
         *
         * 
         * Encapsulation is the concept of wrapping data and methods together and controlling
         * access to them using access modifiers like private, protected, and public.
         * it focuses on protecting internal data form direct access
         *
         * a) protects data
         * b) focuses on restricting access
         * c) archived using access modifiers
         *
         *
         * EX1: Car
         * =========
         * Abstraction
         * - A driver uses accelerator, brake, and steering wheel
         * - The driver does not need to know how the engine works internally
         *
         * Encapsulation
         * - The engine components are hidden inside the car
         * - Users cannot directly change engine parts, they
         *   must interact through the car's controls 
         *
         * EX2: ATM Machine
         * =================
         * Abstraction
         * - A user inserts a card, enters a PIN, and selects withdraw or deposit
         * - The User does not need to know how the bank server verifies the account
         *   or how the machine processes the transaction internally
         *
         *
         * Encapsulation
         * - The account balance and transaction processing are hidden inside the banking system
         * - Users cannot directly change their balance, they must interact through ATM options
         *   like withdraw, deposit, or transfer
         *
         *
         * EX3: TV Remote
         * ===============
         * Abstraction
         * - The user presses buttons like Power, Volume, or Channel
         * - The user does not know the internal electronic circuits
         *
         * Encapsulation
         * - The internal components and signal processing are hidden
         * - Users interact only through the remote buttons 
         * 
         * Abstraction: simple interface for the user
         * Encapsulation: protecting internal implementation 
         * /
        

        #endregion
        
        #region P1Q2
        /*
         * What is the difference between an abstract class and an interface?
         * Give at least four differences. When would you choose on over the other?
         */
        //Solution
        /*
         * Abstract Class
         * - Can contain abstract and concrete methods
         * - Can have fields (variables)
         * - A class can inherit only one abstract class
         * - Can have constructors
         * - Used when classes share common behavior 
         *
         * Interface
         * - Usually contains method signatures only
         * - Cannot have instance fields
         * - A class can implement multiple interfaces
         * - Cannot have constructors
         * - Used to define a capability or contract
         *
         * When to choose each
         * --------------------
         * use an abstract class
         * --> Classes are closely related
         * --> You want to share code (common methods or fields)
         * --> You need constructors or internal state
         *
         * use an interface
         * --> You want to define capability or contract
         * --> Multiple unrelated classes implement the same behavior
         * --> You need multiple inheritance of behavior 
         */

        #endregion
        
        #region P1Q3
        /*
         * public abstract class Appliance {
         *      public string Brand {get; set}
         *      protected Appliance (string brand) {Brand = brand;}
         *      public abstract double PowerConsumption();
         *      public virtual string Status() => "Standby";
         *      public string Label() => $"{Brand} - {PowerConsumption()}W";
         * }
         * public class WashingMachine: Appliance{
         *      public WashingMachine(string band): base (brand){ }
         *      public override double PowerConsumption() => 500;
         *      public override string Status() => "Washing";
         * }
         * public class Toaster: Appliance {
         *      public Toaster(string band) : base (brand) { }
         *      public override double PowerConsumption() => 800;
         * }
         *
         * a) can you write: Appliance a = new Appliance("LG");? why and why not?
         * b) what is the difference between the three methods: PowerConsumption(),
         *    Status(), and Label()? Why did the designer make each one abstract,
         *    virtual, or concrete?
         * c) If you call Status() on a Toaster object, what will it return? Why?
         */
        //Solution
        /*
         * a) no, because appliance is an abstract class, and abstract classes
         *    cannot be instantiated directly, they are meant to be base classes
         *    for other classes
         * b) PowerConsumption()
         *    public abstract double PowerConsumption();
         *      => Abstract method
         *      => Has no implementation
         *      => Must be implemented by every derived class
         *    Reason: different appliance consume different amounts of power
         *
         *    Status()
         *    public virtual string Status() => "Standby";
         *      => Virtual method
         *      => Has a default implementation
         *      => Derived classes may override it if needed
         *    Example: WashingMachine overrides it to "Washing"
         *
         *   Label()
         *   public string Label() => $"{Brand} - {PowerConsumption()}W";
         *      => Concrete method
         *      => Fully implemented in the base class
         *      => Shared by all appliances
         *   Reason: every appliance label follows the same format
         *
         * c) it returns "Standby", because Toaster does not override Status(),
         *    so it uses the base class implementation
         * 
         */
        
        
        

        #endregion
        
        #region P1Q4
        /*
         *=======================
         * File 1: Calculator.cs
         *=======================
         * public partial class Calculator {
         *      public double LastResult {get; private set;}
         *      partial void onCalculated (double result);
         *
         *      public double Add (double a, double b){
         *          LastResult = a + b;
         *          onCalculated(LastResult);
         *          return Last Result;
         *      }
         * }
         *===============================
         * File 2: Calculator.Logging.cs
         *===============================
         * public partial class Calculator{
         *      partial void OnCalculated(double result){
         *          Console.Write($"Log: result = {result}");
         *      }
         * }
         *
         *=============================
         * File 3: DoubleExtensions.cs
         *=============================
         * public static class DoubleExtensions{
         *      public static string ToCurrency(this double value)
         *          => $"${value:F2}";
         * }
         * 
         * a) what is a partial class? Why would a developer split Calculator into 2 files?
         * b) What is a partial method? What happens if the OnCalculated() implementation
         *    in Calculator.Logging.cs is deleted - will the code still compile? Why?
         * c) What is an extension method? what are the three rules for writing one?
         * d) What will the following code print?
         *    Calculator calc = new Calculator();
         *    double result = calc.Add(19.5, 0.5);
         *    Console.WriteLine(result.ToCurrency());
         * 
         */
        //Solution 
        /* a) a partial class allows a class to be split across multiple files,
         *    but all parts are compiled into one class
         *    ex. Calculator.cs, Calculator.Logging.cs
         *    why?
         *      large classes become easier to maintain,
         *      different features can be organized in separate files,
         *      multiple developers work on the same class simultaneously 
         * b) partial method is a method that declared in one part of
         *    a partial class and optionally implemented in another part 
         *    ex. partial void onCalculated(double result);
         *    if the implementation is removed the program still compiles
         *    why? because the compiler removes the method call completely
         *    when no implementation exists
         *
         * c) an extension method allows you to add new methods to
         *    an existing class without modifying its source code
         *    ex. result.ToCurrency()
         *    This works even though double originally has no ToCurrency() method
         *    Three rules for extension methods
         *    1. Must be inside a static class
         *    2. The method itself must be static
         *    3. The first parameter must use the "this" keyword
         *       public static string ToCurrency(this double value)
         *
         * d) output of the code
         *     Calculator calc = new Calculator();
         *     double result = calc.Add(19.5,0.5);
         *     Console.WriteLine(result.ToCurrency());
         *    step1:
         *      19.5 + 0.5 = 20
         *      LastResult = 20
         *    step2:
         *      Partial method logs:
         *      log: result = 20
         *    step3:
         *      Extension method formats the value:
         *      $20.0
         *    Final Output
         *      Log: result = 20
         *      $20.00
         */
        

        #endregion
        
        #region P2
        /*
         * The Cinema manager has reviewed the system and requested three improvements:
         * 1. No Plain Tickets: The manager noticed that in theory, someone could
         * create a plain Ticket object that doesn't belong to any category.
         * This should never happen, every ticket must be either Standard,
         * VIP, IMAX. The system should enforce this at the design level so
         * the compiler itself prevents creating a plain Ticket. At the same time,
         * there are some calculations that every ticket type must provide its own
         * version of (like how the final price is calculated), while other behaviors
         * (like booking and cancellation) should stay shared across all types
         *
         *
         * 2. Organized Cinema Code: The Cinema class is growing too large with ticket management,
         * reporting, and projector control all in one file. The development team wants to split
         * it into multiple files for better organization, without creating separate classes,
         * One file should handle ticket operations (adding tickets, booking), and another should
         * handle reporting (printing all tickets, showing statistics) Both files should contribute
         * to single Cinema class.
         *
         * 
         * 3. Useful Utilities without modifying Existing Classes, The team needs to add some
         * handy features to the existing Ticket types without touching their source code.
         * For example: a method to generate a formatted receipt string from any ticket,
         * and a method that takes an array of tickets and returns the total revenue.
         * These should feel like they belong to the Ticket class when you call them,
         * even though they are defined elsewhere
         *
         * Requirements
         * -> Make the base Ticket class abstract, with at least one abstract method that
         *    each child class must implement
         * -> Using abstract, virtual, and concrete members together in the abstract class
         * -> Using the abstract class for polymorphism (e.g. an array of Ticket hodling different types)
         * -> Splitting the Cinema class using partial classes (at least two files)
         * -> Creating a static class with at least 2 extension methods for Ticket or Ticket-related types
         * -> Calling the extension methods naturally on objects (not as static method calls)
         * 
         */
        Cinema cinema = new Cinema();
        cinema.Open();
        
        //Ticket t4 = new Ticket("test", 100);//error

        Ticket t1 = new StandardTicket("Inception", 80, "A5");
        Ticket t2 = new VIPTicket("Avengers", 200, false, 0);
        Ticket t3 = new IMAXTicket("Dune", 130, true);

        t1.Book();
        t2.Book();
        t3.Book();
        
        cinema.AddTicket(t1);
        cinema.AddTicket(t2);
        cinema.AddTicket(t3);
        cinema.PrintAllTickets();
        Console.WriteLine("---Polymorphism: Final Price per Ticket ---");
        
        Ticket[] _tickets = {t1, t2, t3};
        foreach (var t in _tickets)
        {
            Console.WriteLine($"{t.GetType().Name} => Final Price: {t.FinalPrice():F2}");
            
        }

        Console.WriteLine("---Extension Method: Receipt ---");
        Console.WriteLine(t2.GenerateReceipt());

        Console.WriteLine("---Extension Method: Total Revenue ---");
        Console.WriteLine($"Total Revenue: {_tickets.TotalRevenue():F2}");
        
        cinema.Close();
        #endregion


    }
}
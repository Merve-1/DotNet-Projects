using Assignment_05.Implementation;
using Assignment_05.Interfaces;
using Assignment_05.Shared;
using Assignment_05.Utilities;

namespace Assignment_05;

class Program
{
    static void Main(string[] args)
    {
        #region P1Q1
        /*What is an interface in C#? why do we use interfaces
         instead of depending on concrete classes directly? 
         Mention at least 3 benefits of using interfaces
         */
        // Solution
        /*
         * An interface is a contract that defines a set of methods, properties, or events that a class must implement.
         * It only contains the method signatures not the implementation.
         *
         * Interfaces are used to define what a class can do, without specifying how it does it
         *
         * Benefits:
         *      => Loose Coupling: classes depend on abstractions rather than concrete implementations,
         *                         which makes the system easier to modify and maintain 
         *      => Polymorphism  : different classes can implement the same interface and be used interchangeably
         *      => Better Testing: interfaces allow easy mocking and unit testing because you can replace real
         *                         implementations with test versions 
         *      => Multiple Inheritance Support: c# doesn't allow multiple class inheritance,
         *                                       but a class can implement multiple interfaces
         * 
         */
        

        #endregion
        
        #region P1Q2
        /*
         * interface IEnglishSpeaker{
         *      void Greet();
         * }
         *
         * interface IArabicSpeaker{
         *      void Greet();
         * }
         *
         * class Translator: IEnglishSpeaker, IArabicSpeaker{
         *      public void Greet(){
         *          Console.WriteLine("Hello/ Ahlan");
         *      }
         * }
         *
         * a) What is the problem with this design?
         *    Both interfaces have a method called Greet(),
         *    How does the class handle it currently?
         * b) How would you fix this so IEnglishSpeaker.Greet() says
         *    "Hello" and IArabicSpeaker.Greet() says "Ahlan"?
         *     What is this technique called?
         * c)  After applying fixes, can we call Greet() directly on a Translator object
         *     (e.g. translator.Greet())? Why or Why not? How do you call each version?
         */
        // Solution
        /*
         * a) The problem is both interfaces IEnglishSpeaker and IArabicSpeaker define a method named Greet(),
         *    The Translator class implements both interfaces but only provides one implementation
         *    public void Greet(){ Console.WriteLine("Hello/ Ahlan");}
         *    so no distinguish between the english and arabic greeting
         * b) class Translator: IEnglishSpeaker, IArabicSpeaker{
         *      void IEnglishSpeaker.Greet(){
         *          Console.WriteLine("Hello");
         *      }
         *      void IArabicSpeaker.Greet(){
         *          Console.WriteLine("Ahlan");
         *      }
         *     }
         *     This is explicit interface implementation
         *     it allows a class to implement multiple methods with the same name from different interfaces
         *
         * c) no, cannot be called this way translator.Greet() directly
         *    because the methods are implemented explicitly, they are only accessible through the interface type
         *    Translator translator = new Translator();
         *    ((IEnglishSpeaker)translator).Greet(); //Hello
         *    ((IArabicSpeaker)translator).Greet(); //Ahlan
         *    the object must be casted to the interface to call the correct method 
         */

        #endregion
        
        #region P1Q3
        /*
         * Explain the difference between a shallow copy and a deep copy.
         * When would you use each one?
         * What is the risk of using a shallow copy when the object has reference-type fields?
         * 
         */
        //Solution
        /*
         * Shallow Copy: A shallow copy creates a new object but copies references
         *               of reference-type fields instead of creating new objects
         * Deep Copy:    A deep copy creates a completely independent copy of
         *               the object and all objects it references
         *
         * When to use each
         *      => Shallow Copy: when the object only contains value types,
         *                       or when sharing references is acceptable.
         *      => Deep Copy   : when we want a completely independent duplicate of an object
         *
         * Risk of using shallow copy: if the object contains reference-type fields,
         * both the original and the copy will point to the same referenced object,
         * changing the referenced object in one copy will affect the other object as well
         */

        #endregion
        
        #region P1Q4
        /*
         * Determine the output and explain it
         * class Department {public string Name;}
         * class Employee {
         *      public string Title;
         *      public Department Dept;
         *      public Employee ShallowCopy() => (Employee) this.MemberwiseClone();
         * }
         * var e1 = new Employee {Title = "Dev", Dept = new Department {Name = "IT"}};
         * var e2 = e1.ShallowCopy();
         * e2.Title = "QA";
         * e2.Dept.Name = "Testing";
         * Console.WriteLine($"{e1.Title} - {e1.Dept.Name}");
         * Console.WriteLine($"{e2.Title} - {e2.Dept.Name}");
         */
        //Solution
        /*
         * var e1 = new Employee         //object created
         * {
         *      Title ="Dev",
         *      Dept = new Department {Name ="IT"}
         * }
         * var e2 = e1.ShallowCopy();    // shallow copy is created
         *=================================================================
         * Title is copied normally (string reference copied but immutable)
         * Dept reference is shared between e1 and e2
         *=================================================================
         * e2.Title= "QA"; //this only changes e2.Title
         * e2.Dept.Name = "Testing";//since Dept is shared, both e1 and e2 now reference the same Department object
         *=================================================================
         * output
         * Dev - Testing
         * QA - Testing 
         * 
         */
        

        #endregion
        
        #region P2Q1
        /*
         * Add to the ticketing system interfaces and object copying
         * The cinema manager want to add 3 new capabilities to the booking system
         * 1. Unified Printing:
         *   The manager noticed that different parts of the system print ticket info
         *   in different ways. He wants a standard contract that guarantees any printable
         *   object in the system (tickets, receipts, etc.) can print itself follow this contract,
         *   and each one should print all its tickets using this contract. There should be a
         *   utility method in BookingHelper that can accept an array of any printable objects
         *   and print them all, without knowing their actual types 
         */
        

        #endregion
        
        #region P2Q2
        /*
         * 2. Booking & Cancellation:
         *   Right now, tickets are created but there is no way to track whether a ticket is
         *   actually booked or cancelled. The manager wants every ticket to support booking
         *   and cancellation operations. A ticket can only be booked once (trying to book an
         *   already-booked ticket should fail), and can only be cancelled if it is currently
         *   booked (trying to cancel a non-booked ticket should fail). The booking status should
         *   appear when the ticket is printed 
         */
        

        #endregion
        
        #region P2Q3
        /*
         * 3. Ticket Cloning:
         *   Sometimes a customer wants to buy a second ticket with the exact same details as an
         *   existing one but for a different movie. The system should be able to create a full
         *   independent copy of any ticket (especially VIP tickets). Changing anything on the
         *   copy must NOT affect the original ticket 
         */
        

        #endregion
        
        #region P2Q4
        /*
         * Requirements
         *   use standard C# interfaces like ICloneable
         *   => defining and implementing custom interfaces
         *   => a class implementing multiple interfaces
         *   => using an interface as a method parameter (interface polymorphism)
         *   => implementing ICloneable for deep copying
         *   => proving that the cloned object is fully independent from the original
         */
        Cinema cinema = new Cinema();
        cinema.Open();
        Console.WriteLine();
        StandardTicket t1 = new StandardTicket("Inception", 80, "A5");
        VIPTicket t2 = new VIPTicket("Avengers", 200, true, 50);
        IMAXTicket t3 = new IMAXTicket("Dune", 130, true);

        t1.Book();
        t2.Book();
        t3.Book();

        cinema.AddTicket(t1);
        cinema.AddTicket(t2);
        cinema.AddTicket(t3);
        
        cinema.PrintTickets();

        Console.WriteLine("--- Clone Test ---");
        VIPTicket clone = (VIPTicket)t2.Clone();
        clone.MovieName = "Interstellar";

        Console.WriteLine("Original: ");
        t2.Print();

        Console.WriteLine("Clone   :  ");
        clone.Print();
        Console.WriteLine("--- After cancellation ---");
        t1.Cancel();
        t1.Print();

        Console.WriteLine();
        BookingHelper.PrintAll(new IPrintable[]
        {
         t1,t2, t3
        });

        cinema.Close();

        #endregion
    }
    
}
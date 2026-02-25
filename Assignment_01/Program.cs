namespace Assignment_01;


class Program
{
    static void Main(string[] args)
    {
        #region Q1
        /*
         * Explain with code example how class and struct behave differently
         * Class: reference type, stored on heap, can be null, passed by reference
         * Struct: value type, stored on stack, cannot be null, passed by value
         * class PersonClass{
         *  public string Name;
         * }
         * struct PersonStruct{
         *  public string Name;
         * }
         * class Program{
         *  PersonClass p1 = new PersonClass();
         *  p1.Name = "Ali";
         *
         *  PersonClass p2 = p1;
         *  p2.Name = "Omar";
         *
         *  Console.WriteLine(p1.Name); // same reference
         *
         *  Person s1;
         *  s1.Name = "Ali";
         *  Person s2 = s1;
         *  s2.Name = "Omar;
         *  Console.WriteLine(s1.Name); // copied value
         * 
         * }
         */
        

        #endregion
        
        #region Q2
        /*
         * Explain the difference between public and private access
         * modifiers with an example
         * public: accessible from anywhere
         * private: accessible only inside the same class
         *
         * class BankAccount{
         *  public string Owner;
         *  private double Balance;
         * 
         *  public void Deposit(double amount){
         *      if(amount> 0)
         *          Balance += amount;
         *  }
         *  public double GetBalance(){
         *      return Balance;
         *  }
         * }
         */
        

        #endregion
        
        #region Q3
        /*
         * Describe the steps to create and use a class library in visual studio
         * Create new Library 
         * 1. New Solution
         * 2. Choose Class Library
         * 3. Name it
         * 5. Build the project
         * Use Library
         * 1. Right-Click the Console App
         * 2. Choose Add -> Project Reference
         * 3. Select the class Library
         * 4. Use using LibraryName;
         */
        

        #endregion
        
        #region Q4
        /*
         * What is a class library? why do we use class libraries
         * A class library is a project that contains reusable classes, methods,
         * and logic, but no Main() method
         *===================================
         * why to use class libraries?
         * - code reuse
         * - better project organization
         * - separation of concerns
         * - easier testing
         * - cleaner architecture  
         */
        

        #endregion
        
        #region MovieTicketBookingSystem
        /*
         * User Story: You're building a simple Movie Ticket Booking System
         * for a cinema. The system manages ticket types, seat locations,
         * pricing, and payments. Build it as a Console Application that
         * reads data from the user and prints the booking summary.
            1) Each ticket has a type that can only be one of: standard, VIP, or IMAX.
               How would you represent this?
            2) Type to represent a seat location (Row as char like 'A', 'B', and Number as an int)
               should this be a class or a struct 
            3) Create class with 
                MovieName(Public),
                Type(Public),
                Seat(Public),
                Price(Private)
            Ticket created with all info, or with just the movie name 
            (default type standard, seat A1, price 50), Handle both without repeating initialization logic
            4) Add three methods to the ticket class 
                a. CalcTotal(): receives a taxPercent (double), calculates the total after tax and returns it. 
                    The original price must stay unchanged 
                b. ApplyDiscount(): receives a discountAmount (double). if discount is valid (>0 and <= Price), 
                   deducts it from price and sets discountAmount to 0 (Consumed) otherwise, the discount stays unchanged
                c. PrintTicket(): prints the full ticket info
         */
        Console.Write("Enter movie name: ");
        string movie = Console.ReadLine();

        Console.Write("Enter ticket type (0 = Standard, 1 = VIP, 2 = IMAX): ");
        TicketType type = (TicketType)int.Parse(Console.ReadLine());

        Console.Write("Enter Seat Row (A, B, C...): ");
        char row = char.Parse(Console.ReadLine());

        Console.Write("Enter Seat Number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter Base Price: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("Enter Discount Amount: ");
        double discount = double.Parse(Console.ReadLine());

        Ticket t = new Ticket(movie, type, new Seat(row, number), price);
        
        Console.WriteLine("\n===== Ticket Info =====");
        Console.WriteLine($"Movie      : {movie}");
        Console.WriteLine($"Type       : {type}");
        Console.WriteLine($"Seat       : {row}{number}");
        Console.WriteLine($"Price      : {price:F2}");
        Console.WriteLine($"Total ({14}% tax) : {t.CalcTotal():F2}");

        Console.WriteLine();

        Console.WriteLine("===== After Discount =====");


        Console.WriteLine($"Discount Before : {discount:F2}");

        t.ApplyDiscount(ref discount);

        Console.WriteLine($"Discount After  : {discount:F2}");

        Console.WriteLine($"Movie      : {movie}");
        Console.WriteLine($"Type       : {type}");
        Console.WriteLine($"Seat       : {row}{number}");
        Console.WriteLine($"Price      : {t.GetPrice():F2}");
        Console.WriteLine($"Total ({14}% tax) : {t.CalcTotal():F2}");
        #endregion
    }
}
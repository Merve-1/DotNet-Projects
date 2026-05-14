namespace EF_Core_Assignment01;

using EF_Core_Assignment01.Models;


class Program
{
    static void Main(string[] args)
    {
        /*
         * BookStore
         * Company name: ReadMore Books
         * Need simple db
         * Entities:
         *  Book (Title, ISBN number, price, number of pages, the year of publish, in stock),
         *  Author (first, last names, email address, biography, DoB)
         *  Categories (name, description, active)
         * Relationships (Assumed)
         *  Book Belongs to one category
         *  Book can have one or many authors
         *  
         */
        #region Database Creation

        using var context = new AppDbContext();

     

        Console.WriteLine("Database created successfully!");

        #endregion

        #region Insert Sample Data

        // Create Author
        var author = new Author
        {
            FirstName = "John",
            LastName = "Smith",
            Email = "johnsmith@gmail.com",
            Biography = "Famous programming book writer.",
            DateOfBirth = new DateTime(1980, 5, 10)
        };

        // Create Category
        var category = new Category
        {
            Name = "Programming",
            Description = "Books related to programming and software development.",
            IsActive = true
        };

        // Create Book
        var book = new Book
        {
            Title = "Mastering C#",
            ISBN = "978-1234567890",
            Price = 49.99m,
            NumberOfPages = 550,
            PublishedYear = 2024,
            IsInStock = true,

            // Relationships
            Category = category
        };

        // Add author to book
        book.Authors.Add(author);

        // Save data
        context.Books.Add(book);

        context.SaveChanges();

        Console.WriteLine("Sample data inserted successfully!");

        #endregion

        #region Retrieve Data

        var books = context.Books.ToList();

        Console.WriteLine("\nBooks in Database:\n");

        foreach (var b in books)
        {
            Console.WriteLine($"Title: {b.Title}");
            Console.WriteLine($"ISBN: {b.ISBN}");
            Console.WriteLine($"Price: {b.Price}");
            Console.WriteLine($"Published Year: {b.PublishedYear}");
            Console.WriteLine($"In Stock: {b.IsInStock}");
            Console.WriteLine("--------------------------------");
        }

        #endregion
    }
}
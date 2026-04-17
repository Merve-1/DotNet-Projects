using LinqSession01.Models;

namespace LinqSession01;
class Program
{
    static void Main(string[] args)
    {
        
        var student1 = new
        {
            Name = "Mina",
            Age = 22
        };
        var student2 = new
        {
            Name = "Ayman",
            Age = 21
        };
        Console.WriteLine(student1 == student2);
        var dup = student1 with
        {
            Age = 24
        };
        Console.WriteLine(dup.Age);
        //Functional Programming (Procedural, OOP)  => LINQ
        /*
         * Functions as Values (As Parameter, return it from function)
         * Pure Function (Immutable, no side effect)
         */
        //All LINQ functions are pure function 
        int[] numbers = { 1, 2, 3, 4, 5 };

        var evenNumbers = numbers.Where(n => n % 2 == 0);
        IEnumerable<Product> products = new List<Product>
        {
            new Product
            {
                ProductID = 1, ProductName = "Shrimp", Category = "Seafood", UnitPrice = 15, UnitsInStock = 10
            },

        };
        var p = products
            .Where(p => p.Category.Contains("Seafood")
                        && p.UnitPrice > 10 && p.UnitsInStock > 0)
            .Select(p => new
            {
                p.ProductID, p.Category, p.ProductName
            });
    }
}
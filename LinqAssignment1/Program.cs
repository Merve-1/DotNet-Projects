using LinqAssignment1.DataSources;
using LinqAssignment1.Models;

namespace LinqAssignment1;

class Program
{
    static void Main(string[] args)
    {
        #region #01
        //Get all products from the "Seafood" category. Print each product's name and price 
        Console.WriteLine("1. All products from the Seafood category");
        var result = Source.ProductList
            .Where(p => p.Category == "Seafood")
            .Select(p => new { p.ProductName, p.UnitPrice });

        foreach (var item in result)
        {
            Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
        }

        Console.WriteLine("===================================================================");
        #endregion

        #region #02
        //Get a list of only the product names from ProductList. Print each name.
        Console.WriteLine("2. Products names");
        var productNames = Source.ProductList
            .Select(p => new { p.ProductName});
        foreach (var item in productNames)
        {
            Console.WriteLine($"{item.ProductName}");
        }
        Console.WriteLine("===================================================================");
        #endregion


        #region #03
        //Sort all products by UnitPrice (ascending). Print each product's name and price
        Console.WriteLine("3. UnitPrice Ascending");
        var productInfo = Source.ProductList
            .Select(p => new { p.ProductName, p.UnitPrice })
            .OrderBy(p => p.UnitPrice);
        foreach (var product in productInfo)
        {
            Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
        }
        Console.WriteLine("===================================================================");
        #endregion


        #region #04
        //Get all products where UnitPrice is between 10 and 30
        Console.WriteLine("4. Products Unit Price between 10 and 30");
        var products = Source.ProductList
            .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30)
            .Select(p => new { p.ProductName });
        foreach(var item in products)
            Console.WriteLine($"{item.ProductName}");
        Console.WriteLine("===================================================================");
        #endregion

        #region #05
        //Get all products that are in stock (UnitsInStock >0) and belong to the "condiments" category 
        Console.WriteLine("5. Products that are in Stock and Belong to the Condiments Category");
        var productInStockAndCondiments = Source.ProductList
            .Where(p => p.UnitsInStock> 0 && p.Category == "Condiments")
            .Select(p => new { p.ProductName, p.UnitsInStock });
        foreach (var item in productInStockAndCondiments)
            Console.WriteLine($"{item.ProductName}");
        Console.WriteLine("===================================================================");
        #endregion

        #region #06
        //Create a new anonymous type with three properties: 
        Console.WriteLine("6.Anonymous type with 3 properties");
        /*
         * Name: the product name
         * Price: the unit price
         * StockStatus: a string "Available" is UnitsInStock > 0 otherwise "Out of Stock"
         * Print the result
         *
         */
        /*
         * non-anonymous (productInfo) is a new named class 
         * var items = Source.ProductList.Select(p => new ProductInfo
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
         */
        var items = Source.ProductList.Select(p => new
        {
            Name = p.ProductName,
            Price = p.UnitPrice,
            StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        });
        
        foreach(var item in items)
            Console.WriteLine($"{item.Name} - {item.Price} - {item.StockStatus}");
        Console.WriteLine("===================================================================");
        #endregion

        #region #07
        //Print each Product's name along with its position (1 based) in the list.
        //Expected format 1. Chai, 2. Chang, etc..
        Console.WriteLine("7. Product's name along with its position 1. P1   2. P2   ,etc....");
        var Numbering = Source.ProductList
            .Select((p, index) => new { Index = index + 1, p.ProductName });
        foreach (var item in Numbering)
            Console.WriteLine($"{item.Index}.  {item.ProductName}");
        Console.WriteLine("===================================================================");
        #endregion

        #region #08
        //Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.
        Console.WriteLine("8. Sort ProductList by Category ascending");
        var Sorting = Source.ProductList
            .OrderBy(p => p.Category)
            .ThenByDescending(p => p.UnitPrice)
            .Select(p => new { p.ProductName, p.Category, p.UnitPrice });
        foreach (var item in Sorting)
            Console.WriteLine($"{item.ProductName} - {item.Category} - {item.UnitPrice}");
        Console.WriteLine("===================================================================");
        #endregion

        #region #09
        //Get all products form the "Beverages" category, sorted by UnitsInStock descending. Print name and stock 
        Console.WriteLine("9. All products from the Beverages category, sorted by UnitsInStock descending");
        var beveragesResult = Source.ProductList
            .Where(p => p.Category == "Beverages")
            .OrderByDescending(p => p.UnitsInStock)
            .Select(p => new { p.ProductName, p.UnitsInStock });
        foreach (var item in beveragesResult)
            Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}");
        Console.WriteLine("===================================================================");
        #endregion

        #region #10
        //Using QUERY SYNTAX with a compound from clause, list all orders placed
        //in 1997 or later showing CustomerID and OrderDate

        Console.WriteLine("10. Using QUERY Syntax with a compound from clause");
        var QuerySyntax = 
            from customer in Source.CustomerList
            from order in customer.Orders
            where order.OrderDate.Year >= 1997
            select new { customer.CustomerID,  order.OrderDate};
                        
        foreach (var item in QuerySyntax)
            Console.WriteLine($"{item.CustomerID} - {item.OrderDate}");
        Console.WriteLine("===================================================================");
        #endregion

        #region #11
        //Show position number alongside ProductName
        Console.WriteLine("11. Position number + ProductName");
        var positionNum_ProdName = Source.ProductList
            .Select((p, i) => new { Position = i + 1, p.ProductName });
        foreach (var item in positionNum_ProdName)
            Console.WriteLine($"{item.Position} - {item.ProductName}");
        Console.WriteLine("===================================================================");
        #endregion

        #region #12
        //Sort first by word length and then by a case-insensitive sort of the words in an array 
        Console.WriteLine("12. Sort first by word length and then by a case-insensitive");
        String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BLUeBeRry","CLOvEr","cHeRry"};
        var values = Arr
            .OrderBy(word => word.Length)
            .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);
        foreach (var item in values)
            Console.WriteLine(item);
        
        Console.WriteLine("===================================================================");
        #endregion

        #region #13
        /*
         * Create a list of all digits in the array whose second letter
         * is 'i' that is reversed from the order in the original array
         */
        Console.WriteLine("13. List of all digits in the array whose second letter is 'i'");
        string[] digits = { "zero","one","two","three","four","five","six","seven","eight","nine" };
        var reverseDigits = digits
            .Where(d => d.Length > 1 && d[1] == 'i')
            .Reverse();
        foreach (var item in reverseDigits)
            Console.WriteLine(item);
        Console.WriteLine("===================================================================");
        #endregion

    }
}
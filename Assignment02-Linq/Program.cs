using LinqAssignment1.DataSources;

namespace Assignment02_Linq;

class Program
{
    static void Main(string[] args)
    {
        #region Q1

        //Get top 3 most expensive products
        Console.WriteLine("================== Q1 ==================");
        var result1 = Source.ProductList
            .OrderByDescending(p => p.UnitPrice)
            .Take(3);
        foreach (var item in result1)
            Console.WriteLine($"Products: {item}");
        Console.WriteLine("========================================");

        #endregion

        #region Q2

        //Show page 2 of products, with page size = 5
        Console.WriteLine("================== Q2 ==================");
        var result2 = Source.ProductList
            .Skip(5)
            .Take(5);
        foreach (var item in result2)
            Console.WriteLine($"Products: {item}");
        Console.WriteLine("========================================");

        #endregion

        #region Q3

        //Take products from the list as long as
        //Their UnitPrice is less than $25 (list is ordered by price)
        Console.WriteLine("================== Q3 ==================");
        var result3 = Source.ProductList
            .OrderBy(p => p.UnitPrice)
            .TakeWhile(p => p.UnitPrice < 25);

        foreach (var item in result3)
            Console.WriteLine($"Products: {item}");
        Console.WriteLine("========================================");

        #endregion

        #region Q4

        //Check if ALL products in the "Seafood" Category are in stock 
        Console.WriteLine("================== Q4 ==================");
        bool result4 = Source.ProductList
            .Where(p => p.Category == "Seafood")
            .All(p => p.UnitsInStock > 0);
        Console.WriteLine($"All of the products in the seafood category are in stock: {result4}");
        Console.WriteLine("========================================");

        #endregion

        #region Q5

        //Check if the ID list contains 9 
        //int[] ids = {3,9,13,18};
        Console.WriteLine("================== Q5 ==================");
        int[] ids = { 3, 9, 13, 18 };
        bool result5 = ids.Contains(9);
        Console.WriteLine("The result is " + result5);
        Console.WriteLine("========================================");

        #endregion

        #region Q6

        //Group all products by Category and print each group with its product count
        Console.WriteLine("================== Q6 ==================");
        var result6 = Source.ProductList
            .GroupBy(p => p.Category);
        foreach (var item in result6)
            Console.WriteLine($"{item.Key} - Count:  {item.Count()}");
        Console.WriteLine("========================================");

        #endregion

        #region Q7

        //Group products by Category and project only product names per group 
        Console.WriteLine("================== Q7 ==================");
        var result7 = Source.ProductList
            .GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Names = g.Select(p => p.ProductName)
            });
        foreach (var item in result7)
            Console.WriteLine($"{item.Category} - {item.Names}");
        Console.WriteLine("========================================");


        #endregion

        #region Q8

        //Find all Categories that have more than 3 products 
        Console.WriteLine("================== Q8 ===================");
        var result8 = Source.ProductList
            .GroupBy(p => p.Category)
            .Where(g => g.Count() > 3)
            .Select(g => g.Key);

        Console.WriteLine("=========================================");

        #endregion

        #region Q9

        //Using Query Syntax, group customers by Country,
        //and for each group select {Country, Count, TotalOrderValue}
        Console.WriteLine("================== Q9 ===================");
        var result9 =
            from c in Source.CustomerList
            group c by c.Country
            into g
            select new
            {
                Country = g.Key,
                Count = g.Count(),
                TotalOrderValue = g.SelectMany(c => c.Orders).Sum(o => o.Total)
            };
        foreach (var item in result9)
            Console.WriteLine($"{item.Country} - {item.Count} - {item.TotalOrderValue}");
        Console.WriteLine("=========================================");

        #endregion

        #region Q10

        //Calculate the total number of units in stock across all products 
        Console.WriteLine("================== Q10 ==================");
        var total = Source.ProductList
            .Sum(p => p.UnitsInStock);
        Console.WriteLine($"{total}");
        Console.WriteLine("=========================================");

        #endregion

        #region Q11

        //Find the CHEAPEST and most EXPENSIVE product prices
        Console.WriteLine("================== Q11 ==================");
        var min = Source.ProductList.Min(p => p.UnitPrice);
        var max = Source.ProductList.Max(p => p.UnitPrice);
        Console.WriteLine($"Min: {min} - Max: {max}");
        Console.WriteLine("=========================================");

        #endregion

        #region Q12

        //Get a distinct list of all product categories 
        Console.WriteLine("================== Q12 ==================");
        var result12 = Source.ProductList
            .Select(p => p.Category)
            .Distinct();
        foreach (var item in result12)
            Console.WriteLine("Category: {0}", item);
        Console.WriteLine("=========================================");

        #endregion

        #region Q13

        //Find product IDs that are in setA but NOT in setB
        //int[] setA = {1,3,5,7,9,11,13};
        //int[] setB = {3,6,9,12,15,13};
        Console.WriteLine("================== Q13 ==================");
        int[] setA = {1,3,5,7,9,11,13 };
        int[] setB = { 3, 6, 9, 12, 15, 13 };

        var result13 = setA.Except(setB);
        Console.WriteLine($"{result13.Count()} numbers - {string.Join(",", result13)}");
        Console.WriteLine("=========================================");

        
        #endregion

        #region Q14
        //Find countries that appear in list1 but not in list2 (case-insensitive)
        Console.WriteLine("================== Q14 ==================");
        string[] list1 = {"Egypt", "UAE", "Qatar", "sudan"};
        string[] list2 = {"USA", "UAE", "Italy", "Sudan"};
        var result14 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine($"{result14.Count()} values - {string.Join(",", result14)}");
        Console.WriteLine("=========================================");

        #endregion

        #region Q15
        //Build a Dictionary <int, Product> keyed by ProductID
        //then retrieve and print the product with ID = 18
        Console.WriteLine("================== Q15 ==================");
        var dict = Source.ProductList
            .ToDictionary(p => p.ProductID);
        var product = dict[18];
        Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
        Console.WriteLine("=========================================");


        #endregion

        #region Q16
        //Get the first product whose price is greater than $50
        Console.WriteLine("================== Q16 ==================");
        var result16 = Source.ProductList
            .First(p => p.UnitPrice > 50);
        Console.WriteLine($"{result16.ProductName} - {result16.UnitPrice}");
        Console.WriteLine("=========================================");

        #endregion

        #region Q17
        //Try to get the first product with a price> $500.
        //it returns null instead of throwing 
        Console.WriteLine("================== Q17 ==================");
        var result17 = Source.ProductList
            .FirstOrDefault(p => p.UnitPrice > 500);
        if (result17 != null)
        {
            Console.WriteLine($"{result17.ProductName} - {result17.UnitPrice}");
        }
        else
        {
            Console.WriteLine("No product found.");
        }
        Console.WriteLine("=========================================");

        #endregion

        #region Q18
        //Generate a multiplication table row for 7
        Console.WriteLine("================== Q18 ==================");
        var result18 = Enumerable.Range(1, 10)
            .Select(x => $"7 x {x} = {7 * x}");
        foreach (var value in result18)
            Console.WriteLine($"{value}");
        Console.WriteLine("=========================================");

        #endregion

        #region Q19
        //Generate even numbers between 1 and 30 
        Console.WriteLine("================== Q19 ==================");
        var result19 = Enumerable.Range(1, 30)
            .Where(x => x % 2 == 0);

        foreach (var item in result19)
            Console.WriteLine($"{item}");
        Console.WriteLine("=========================================");

        #endregion

        #region Q20
        //Concatenate the first 3 product names with the
        //first 3 customer company names into a single sequence 
        Console.WriteLine("================== Q20 ==================");
        var result20 = Source.ProductList
            .Select(p => p.ProductName)
            .Take(3)
            .Concat(
                Source.CustomerList
                    .Select(c => c.CompanyName)
                    .Take(3));
        foreach (var item in result20)
            Console.WriteLine($"{item}");
        Console.WriteLine("=========================================");

        #endregion

        #region Q21
        //Pair each product with a customer (by position)
        //and produce a string "ProductName sold to CompanyName"
        Console.WriteLine("================== Q21 ==================");
        var result21 = Source.ProductList
            .Zip(Source.CustomerList,
                (p, c) => $"{p.ProductName} sold to {c.CompanyName}");
        foreach (var item in result21)
            Console.WriteLine($"{item}");
        Console.WriteLine("=========================================");

        #endregion
    }
}

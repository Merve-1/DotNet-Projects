namespace OnlineStoreOrderProcessing;


class Program
{
    static void Main(string[] args)
    {
        /*
         * You just got hired as a junior developer at "ShopMaster", a
         * growing online store. Your manager gives you a list of features
         * to build for the store's backend system. The system needs to
         * handle products, orders, notifications, and reports. "We need
         * this system to be flexible. Tomorrow we might add new
         * product categories, new discount rules, new notificaiton
         * channels, new report formats... so don't hardcode anything. I
         * want to be able to plug in new behavior without changing
         * existing code - making the system easy to extend without
         * modification.
         */


        List<Product> catalog = new()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
            new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
            new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
            new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
            new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
            new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
            new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
            new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
        };
        
        /*
         * The method should return a List containing only the products that satisfy the condition. Then, call this method four times with different lambda expressions to perform the following searches:
            1. All Electronics products
            2. Products cheaper than $50
            3. Products that are in stock (Stock > 0)
            4. Clothing products under $100

         */

        //Electronics 
        Console.WriteLine("--- Electronics ---");

        var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
        foreach (var p in electronics)
        {
            Console.WriteLine($"{p.Name}-${p.Price} (Stock: {p.Stock})");
        }
        
        //Under $50
        Console.WriteLine("--- Under $50 ---");
        var cheap = SearchProducts(catalog, p => p.Price < 50);
        foreach (var p in cheap)
        {
            Console.WriteLine($"{p.Name}-${p.Price} (Stock: {p.Stock})");
        }
        
        //In Stock
        Console.WriteLine("--- In Stock ---");
        var inStock = SearchProducts(catalog, p => p.Stock > 0);
        foreach (var p in inStock.Take(4))
        {
            Console.WriteLine($"{p.Name}-${p.Price} (Stock: {p.Stock})");
        }
        
        //Clothing under 100
        Console.WriteLine("--- Clothing Under $100 ---");
        var clothing = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
        foreach (var p in clothing)
        {            
            Console.WriteLine($"{p.Name}-${p.Price} (Stock: {p.Stock})");
        }

        //Scenario 1  Short Report: Print each product as Name - $Price 
        Console.WriteLine("--- Short Report ---");
        PrintReport(catalog.Take(6).ToList(), p =>
        {
            Console.WriteLine($"{p.Name}-${p.Price}");
        });
        
        //Scenario 2  Detailed Report: Print each product as [Category] Name | Price: $X | Stock: Y 
        Console.WriteLine("--- Detailed Report ---");
        PrintReport(catalog.Take(7).ToList(), p =>
        {
            Console.WriteLine($"[{p.Category}] {p.Name} | Price: {p.Price} | Stock: {p.Stock}");
        });
        
        // Scenario 3 Summary List: Transform each product into a string like "Laptop ($1200)". Print all results. 
        Console.WriteLine("--- Summary List ---");
        var summary = TransformProducts(catalog.Take(7).ToList(),
            p => $"{p.Name} (${p.Price})");
        foreach (var item in summary)
        {
            Console.WriteLine(item);
        }
            
        
        //Scenario 4 Price Label: Transform each product into "Expensive!"
        //if Price > $100, or "Affordable" otherwise. Print each as Name: Label.
        Console.WriteLine("--- Product Labels ---");
        var labels = TransformProducts(catalog
            .Where(p => new[] { 1, 2, 3, 8,9,10,11 }.Contains(p.Id))
            .ToList(), p=> 
            $"{p.Name}: {(p.Price > 100? "Expensive!": "Affordable")}");
        foreach (var item in labels)
            Console.WriteLine(item);
        
        //Scenario 5  Low-Stock Alert: Find products with Stock
        //< 20 and print an alert for each in the format: [LOW STOCK] Name: only X left!
        Console.WriteLine("--- Low-Stock Alert ---");
        var lowStock = FilterProducts(catalog, p => p.Stock < 20);
        foreach (var p in lowStock)
        {
            Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
        }
        
    }
    /*
      Manager: Customers search in all kinds of ways - by category, by price, by name,
      by stock... and the list keeps growing. I need ONE search method that works for
      any filter, now and in the future, without being modified.
      What You Need To Do: Write a single method called SearchProducts that accepts two parameters: 
        1. The product list (List<Product>) 
        2. A delegate representing the filter condition (Func<Product , bool>) 
     ---Why to use Func<Product, bool>---
     - Because it allows dynamic filtering logic without modifying the method,
     - this satisfies the requirements "extend without modification"
     */

    public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
    {
        List<Product> result = new(); 
        foreach (var p in  products)
        { 
            if(filter(p)) 
                result.Add(p);
        }
        return result; 
    }
    
    /*
       Manager: "We need different reports from the same data - a quick summary, a detailed breakdown,
       a low-stock alert. Build one reporting engine where the caller controls the format. Use the 
       built-in delegates this time."
     */
    //=================================================================================================
    /*
     * 3.1  Print Reports 
        Write a method called PrintReport that accepts the product list and an Action. 
        The method loops through all products and calls the action on each one. 
        The caller decides what to print by passing a lambda. 
    */
    // Action<Product>: used because an action (printing) is used without returning anything
    public static void PrintReport(List<Product> products, Action<Product> action)
    {
        foreach (var p in products)
        {
            action(p);
        }
    }
    /*
     * 3.2. Transform Products 
        Write a method called TransformProducts that accepts the product list and a Func. 
        The method returns a List by applying the function to each product. 
     */
    // Func<Product, TResult> → used because we transform Product into another type
    public static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transformer)
    {
        List<TResult> result = new();
        foreach (var p in products)
        {
            result.Add(transformer(p));
        }
        return result;
    }
    /*
     * 3.3. Filter Products 
        Write a method called FilterProducts that accepts the product list and a Predicate. The method returns a List of products that match the condition. 
     */
    // Predicate<Product> → specialized delegate for filtering (returns bool)
    public static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
    {
        List<Product> result = new();
        foreach (var p in products)
        {
            if (condition(p))
                result.Add(p);
        }
        return result;
    }
    
}
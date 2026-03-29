namespace Adv;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Exercise 1: Student Grade Manager
            Create a program that manages student grades using One Of Collections
            Create a Collection with these grades: 85, 92, 78, 95, 88, 70, 100, 65
            Print the collection, Count, first and last grade
            Sort the grades ascending, then print
            Get the first grade above 90
            Get all grades below 75 (failing grades)
            Remove all failing grades (below 75)
            Check if any grade equals 100
            Create a List<string> where each grade becomes "Grade: X"

         */

        Console.WriteLine("=========Grades Collection=========");
        //Create a Collection 
        List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };
        
        //Print collection
        Console.WriteLine("Grades: " +string.Join(", ", grades));
        Console.WriteLine("Count: "+ grades.Count);
        Console.WriteLine("First: "+grades.First());
        Console.WriteLine("Last: "+grades.Last());
        
        //Sort ascending 
        grades.Sort();
        Console.WriteLine("Sorted: " + string.Join(", ", grades));

        //First grade above 90
        var above90 = grades.FirstOrDefault(g => g > 90);
        Console.WriteLine("Above 90: " + above90);

        //Grades below 75
        var failing = grades.Where(g => g < 75).ToList();
        Console.WriteLine("Failing: " + string.Join(", ", failing));
        
        //Remove failing grades
        grades.RemoveAll(g => g < 75);
        Console.WriteLine("After removal: " + string.Join(", ", grades));

        //Check if any grade equals 100
        Console.WriteLine("Has 100: "+ grades.Any(g => g == 100));

        //Convert to List<string>
        var gradeStrings = grades.Select(g => $"Grades: {g}").ToList();
        Console.WriteLine(string.Join(", ", gradeStrings));
        Console.WriteLine("=========================================================");
        /*
         * Exercise 2: Leaderboard
            Create a leaderboard that automatically sorts players by score.
            Add: 500="Ahmed", 200="Sara", 800="Ali", 350="Mona"
            Print all entries (they should be sorted by score automatically)
            Access the first key and first value
            Check if score 500 exists
            Safely get the player with score 999
            Remove the player with score 200 and print the updated list

         */

        Console.WriteLine("=========Leaderboard Sorted Dictionary=========");

        //Sorted Dictionary (key-value pairs)
        SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>()
        {
           {500,"Ahmed"},
           {200,"Sara"},
           {800,"Ali"},
           {350,"Mona"},
        };
        //Print All entries by score 
        foreach (var leader in leaderboard)
           Console.WriteLine($"{leader.Key}:  {leader.Value}");
        
        //Access the first key & first value
        Console.WriteLine("First Key: " + leaderboard.First().Key);
        Console.WriteLine("First Value: " + leaderboard.First().Value);
        
        //Check if score 500 exists 
        Console.WriteLine("Contains 500: "+ leaderboard.ContainsKey(500));
        
        //Get the player with score 999
        if(leaderboard.TryGetValue(999, out string player))
           Console.WriteLine(player);
        else
           Console.WriteLine("Score 999 not found");
        
        //Remove player with score 200 and print the updated list 
        leaderboard.Remove(200);
        Console.WriteLine("After removal: ");
        foreach (var leader in leaderboard)
           Console.WriteLine($"{leader.Key}: {leader.Value}");
     
        Console.WriteLine("=========================================================");
  
        /*
         * Exercise 3: Phone Book
            Build a phone book application.
            Create a Collection  with 4 contacts (name → phone number)
            Add a new contact using [] syntax (add or update)
            Try adding a duplicate using .Add() — catch the exception and print the error
            Try adding a duplicate using .TryAdd() — print whether it succeeded
            Search for a contact that doesnot exist
            Get a contact with a fallback of "Not Found"
            Print all Keys on one line, then all Values on another line

         */
        Console.WriteLine("=========Phone Book Dictionary=========");

        //Dictionary 
        Dictionary<string, string> phoneBook = new Dictionary<string, string>()
        {
           {"Ahmed","01123456789"},
           {"Sara", "01223456789"},
           {"Ali",  "01233456789"},
           {"Mona", "01234456789"}
        };
        
        //Add new contact using [] syntax
        phoneBook["Wael"] = "01234556789";
        //Try adding a duplication using (Add)
        try
        {
           phoneBook.Add("Mariam", "01234566789");
        }
        catch (Exception e)
        {
           Console.WriteLine(e);
           throw;
        }
        //Try adding a duplicate using (TryAdd)
        bool added = phoneBook.TryAdd("Maged", "01234567789");
        Console.WriteLine("TryAdd Status: " + added);
        //Search for a contact that doesnot exist 
        Console.WriteLine(phoneBook.ContainsKey("Deniz"));
        //Get a contact with a fallback of not found 
        string value = phoneBook.GetValueOrDefault("Mohammed", "Not Found");
        Console.WriteLine(value);
        //Print all keys on one line and all values on another line 
        Console.WriteLine(string.Join(", ", phoneBook.Keys));
        Console.WriteLine(string.Join(", ", phoneBook.Values));
        
        /*
         * Exercise 4: Unique Email Validator
            Use Collection to manage unique email addresses.
            Create a HashSet<string> with a case-insensitive comparer: new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com", "Sara@Test.Com"
            Print Count — how many are actually stored? Explain why.
            Create two sets: Set A = {1,2,3,4,5} and Set B = {4,5,6,7,8}
            Print the result of: UnionWith, IntersectWith, ExceptWith
            Use IsSubsetOf to check if {1,2} is a subset of Set A

         */

        Console.WriteLine("=========Unique Email Validator HashSet=========");

        //HashSet
        var emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
           "ahmed@test.com",
           "AHMED@test.com",
           "sara@test.com",
           "Sara@Test.Com"
        };

        //Print the count 
        Console.WriteLine("Count: " + emails.Count);//2 as it ignores case sensitivity 
           
        //Create 2 sets A & B
        var setA = new HashSet<int> { 1, 2, 3, 4, 5 };
        var setB = new HashSet<int> {4,5,6,7,8};
        
        //Print the result of: UnionWith, IntersectWith, ExceptWith
        var union = new HashSet<int>(setA);
        union.UnionWith(setB);
        Console.WriteLine("Union: " + string.Join(", ", union));
        
        var intersect = new HashSet<int>(setA);
        intersect.IntersectWith(setB);
        Console.WriteLine("Intersect: "+string.Join(", ", intersect));

        //ExceptWith => removes from the current set all of the elements that are also in the another set 
        var except = new HashSet<int>(setA);
        except.ExceptWith(setB);
        Console.WriteLine("Except: " + string.Join(", ", except));

        
        //Use IsSubsetOf to check if {1,2} is a subset of Set A
        Console.WriteLine(new HashSet<int>{1,2}.IsSubsetOf(setA));
        
        Console.WriteLine("=========================================================");


        /*
         * Exercise 5: Print Queue Simulator
            Simulate a printer queue
            Create a Queue<string> and enqueue 5 documents: "Report.pdf", "Invoice.pdf", "Letter.docx", "Resume.pdf", "Photo.jpg"
            Print the queue contents and Count
            Use Peek to see which document will print next (without removing)
            Process the queue: Dequeue each document and print "Printing: [name]"
            Try TryDequeue on the now-empty queue — what happens?


         */
        Console.WriteLine("=========Print Queue Simulator=========");
        //Queue
        Queue<string> queue = new Queue<string>();
        
        queue.Enqueue("Report.pdf");
        queue.Enqueue("Invoice.pdf");
        queue.Enqueue("Letter.docx");
        queue.Enqueue("Resume.pdf");
        queue.Enqueue("Phone.jpg");

        //Print the queue contents and count 
        Console.WriteLine(string.Join(", ", queue));
        Console.WriteLine("Count: "+queue.Count);
        
        //Use Peek to see which document will print next 
        Console.WriteLine("Next: " + queue.Peek());
        
        //Process the queue
        while(queue.Count > 0)
           Console.WriteLine("Printing: "+ queue.Dequeue());
        
        //Try TryDequeue 
        if(queue.TryDequeue(out string doc))
           Console.WriteLine(doc);
        else
           Console.WriteLine("Queue is empty");
        Console.WriteLine("=========================================================");

        /*
         * Exercise 6: Browser History (Undo)
            Simulate browser back/forward
            Create a Stack<string> for browser history
            Push 5 URLs: "google.com", "github.com", "stackoverflow.com", "youtube.com", "claude.ai"
            Use Peek to see the current page (top of stack)
            Press "back" 3 times using Pop — print each page you leave
            Print the current page after going back
            Try TryPop on an empty stack — what happens?

         */
        Console.WriteLine("=========Browser History Stack=========");
        
        //Stack
        Stack<string> history = new Stack<string>();
        
        history.Push("google.com");
        history.Push("github.com");
        history.Push("stackoverflow.com");
        history.Push("youtube.com");
        history.Push("claude.ai");
        
        //Use Peek to see the current page 
        Console.WriteLine("Current: " + history.Peek());
        
        //Press back 3 times using pop, print each page you leave
        for(int i =0;i<3; i++)
            Console.WriteLine("Leaving: "+ history.Pop());
        
        //Print the current page after going back 
        Console.WriteLine("Current after back: "+history.Peek());
        
        //Try TryPop on an empty stack 
        while (history.Count > 0)
           history.Pop();
        if(history.TryPop(out string page))
           Console.WriteLine(page);
        else
           Console.WriteLine("Stack is empty");
        
        Console.WriteLine("=========================================================");

    }
}
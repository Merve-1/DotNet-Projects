namespace AdvAssignment_01;

class Program
{
    static void Main(string[] args)
    {
        #region Q1
        //What is a generic class? Why use generics?
        /*
         * A generic class is a class that works with different data types using type parameters
         * class Box<T>
         * {
         *      public T Value;
         * }
         * -> Type safety (no casting)
         * -> Code reuse
         * -> Better performance than object
         */
        
        #endregion
        
        #region Q2
        //Write a generic class Container<T>  with Add and Get methods
        /*
         * using System.Collections.Generic;
         * class Container<T>
         * {
         *      private List<T> items = new List<T>();
         *
         *      public void Add(T item){
         *          items.Add(item);
         *      }
         *
         *      public T Get(int index){
         *          return items[index];
         *      }
         * }
         * Container<int> c = new Container<int>();
         * c.Add(10);
         * Console.WriteLine(c.Get(0));
         */
        
        #endregion
        
        #region Q3
        //What are multiple type parameters? Write Pair<TKey, TValue>
        /*
         * Multiple type parameters allow a class to work with more than one type
         * class Pair<TKey, TValue>
         * {
         *      public TKey Key{get;set;}
         *      public TValue Value{get; set;}
         *
         *      public Pair(TKey key, TValue value){
         *          Key = key;
         *          Value = value;
         *      }
         *
         * }
         * Pair<int, string> p = new Pair<int, string> (1, "Apple");
         * 
         */
        
        #endregion
        
        #region Q4
        //What is a generic method? Write Swap<T> method
        /*
         * A generic method works with any type
         * public static void Swap<T> (ref T a, ref T b) {
         *      T temp = a;
         *      a = b;
         *      b = temp;
         * }
         *
         * int x = 5;
         * int y = 10;
         * Swap(ref x, ref y);
         */
        
        #endregion
        
        #region Q5
        //Write a generic method FindMax<T> that finds maximum value
        /*
         * public static T FindMax<T> (T a, T b) where T: IComparable<T>
         * {
         *      if(a.CompareTo(b) > 0)
         *          return a;
         *      else
         *          return b;
         *
         * }
         *
         * Console.WriteLine(FindMax(10, 20));
         */
        
        #endregion
        
        #region Q6
        //What is a generic interface? Write IRepository<T>
        /*
         * A generic interface defines operations for any type
         * interface IRepository<T>{
         *      void Add(T item);
         *      void Delete(T item);
         *      T GetById(int id);
         * }
         *
         * implementation
         * class ProductRepository: IRepository<Product>
         * {
         *      public void Add(Product item) {}
         *      public void Delete(Product item) {}
         *      public Product GetById(int id){
         *          return new Product();
         *      }
         * }
         */
        
        #endregion
        
        #region Q7
        //What is the 'struct' constraint? Write an example
        /*
         * It restricts the type to value types only
         *
         * class StructExample<T> where T: struct{
         *   public T Value;
         * }
         *
         * StructExample<int> s = new StructExample<int>();
         */
        
        #endregion
        
        #region Q8
        //What is the 'class' constraint? Write an example
        /*
         * Restricts the type to reference types
         * class ClassExample<T> where T: class{
         *   public T Value;
         * }
         *
         * ClassExample<string> obj = new ClassExample<string> ();
         */
        
        #endregion
        
        #region Q9
        //What is the 'new()' constraint? Write an example
        /*
         * Requires a parameterless constructor
         * class Factory<T> where T: new(){
         *   public T Create(){
         *      return new T();
         *   }
         * }
         *
         * Factory<MyClass> f = new Factory<MyClass>();
         * MyClass obj = f.Create();
         */
        
        #endregion
        
        #region Q10
        //What is the interface constraint? Write an example 
        /*
         * Restricts T to types implementing an interface
         * class Worker<T> where T: IDisposable{
         *    public void Close(T obj)
         *    {
         *       obj.Dispose();
         *    }
         * }
         */
        
        #endregion
        
        #region Q11
        //What is the base class constraint? Write an example.
        /*
         * Restricts T to types derived from a base class
         * class Animal{}
         * class Dog: Animal {}
         * class Zoo<T> where T: Animal {
         *   public void Add (T animal) {  }
         * }
         *
         * Zoo<Dog> zoo = new Zoo<Dog>();
         */
        
        #endregion
        
        #region Q12
        //How do you apply multiple constraints? Write an example 
        /*
         * you can combine constraints
         * class Example<T> where T: class, IDisposable, new() {
         *   public T Create(){
         *     T obj = new T();
         *     return obj;
         *   }
         * }
         * 
         */
        #endregion
        
        #region Q13
        //What does the 'default' keyword do in generics?
        /*
         * Returns the default value of a type
         * int    => 0
         * bool   => false
         * string => null
         * object => null
         *
         * T value = default(T);
         */
        
        #endregion
        
        #region Q14
        //Write a SafeList<T> that returns default when the index is invalid.
        /*
         * using System.Collections.Generic;
         * class SafeList<T>
         * {
         *    public List<T> items = new List<T>();
         *    public void Add(T item){
         *       items.Add(item);
         *    }
         *    public T Get(int index){
         *       if(index < 0 || index >= items.Count)
         *            return default;
         *       return items[index];
         *    }
         * }
         */
        
        #endregion
        
        #region Q15
        //What is covariance? Explain the 'out' keyword 
        /*
         * Covariance allows return types to be more specific
         * Used with interfaces and delegates
         *
         * interface<IReadOnly<out T>{
         *    T Get();
         * }
         *
         * IEnumerable<string> -> IEnumerable<object>
         *
         * Because string derives from object
         * 
         */
        
        #endregion
        
        #region Q16
        //What is contravariance? Explain the 'in' keyword
        /*
         * Contravariance allows method parameters to be less specific
         *
         * interface IProcessor<in T>{
         *    void Process(T item);
         * }
         *
         * Action<object> -> Action<string>
         */
        
        #endregion
        
        #region Q17
        //What is the difference between covariance and contravariance?
        /*
         * => Covariance: keyword(out), used for return types, direction derived -> base
         * => Contravariance: keyword(in), used for method parameters, direction base -> derived
         *
         * IEnumerable<string> -> IEnumerable<object> (Covariance)
         * Action<object> -> Action<string> (Contravariance)
         */
        #endregion
        
        #region Q18
        //How do static members work in generic types? 
        /*
         * Each closed generic type gets its own static members
         * class Counter<T>
         * {
         *    public static int Count;
         * }
         * Counter<int>.Count= 5;
         * Counter<string.Count = 10;
         */
        #endregion
        
        #region Q19
        //How can you inherit from a generic class? 
        /*
         * class Base<T>{
         *   public T Value;
         * }
         * class Derived<T> : Base<T>{ }
         *
         * Fixed type
         * class IntBase: Base<int>
         */
        #endregion
        
        #region Q20
        //Complete Exercise - Create a generic Cache <TKey, TValue> with
        //Add, Get, Remove, Contains, and expiration support 
        Cache<int,string> cache = new Cache<int,string>();
        cache.Add(1, "Hello", 60);
        cache.Add(2, "World", 60);
        cache.Add(3, "!!!!!", 60);
        Console.WriteLine(cache.Get(2));
        Console.WriteLine(cache.Contains(4));
        cache.Remove(2);
        Console.WriteLine(cache.Contains(2));
        #endregion
    }
}
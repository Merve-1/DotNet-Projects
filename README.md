# 🎬 Movie Ticket Booking System (C# OOP)

Topics covered:

- Interfaces in C#
- Explicit Interface Implementation
- Shallow Copy vs Deep Copy
- Object cloning using `MemberwiseClone()`

## Questions

### Q1 — Interfaces in C#
Explanation of what interfaces are and why they are used instead of concrete classes.
<img width="298" height="169" alt="images" src="https://github.com/user-attachments/assets/f241c7b1-0fbd-4df9-abe0-07d50881d625" />

Benefits discussed include:

- Loose coupling
- Better testability
- Polymorphism support


---

### Q2 — Multiple Interfaces With Same Method
<img width="616" height="355" alt="image" src="https://github.com/user-attachments/assets/e891eb51-bfa0-4029-a36d-ae9e59101055" />


### Q3 — Explain the difference between a shallow copy and a deep copy. 
<img width="810" height="362" alt="image" src="https://github.com/user-attachments/assets/cee70da4-d527-4d84-8b70-bc9a396ff7c3" />

### Shallow Copy Meaning

A shallow copy 
* When the object only contains value types
* Or when sharing references is acceptable.

A deep copy
* When you want a completely independent duplicate of an object

### Q4 — Clone Method and `ICloneable` Interface Explanation

1. What is `Clone()`?

`Clone()` is a method used to **create a copy of an existing object**. Instead of manually creating a new object and copying all properties, the `Clone()` method allows duplicating the object easily.

Example from the code:

```csharp
public override object Clone()
{
    IMAXTicket clone = (IMAXTicket)this.MemberwiseClone();
    clone.TicketNumber = new Random().Next(100, 999);
    return clone;
}
```

### What happens 

1. `MemberwiseClone()` creates a **shallow copy** of the current object.
2. The copied object is stored in `clone`.
3. A **new ticket number** is generated so the cloned ticket is unique.
4. The cloned object is returned.

This allows the program to copy ticket information such as:

* Movie name
* Price
* IMAX / 3D settings

while still assigning a **different ticket ID**.

---

# 2. What is `MemberwiseClone()`?

`MemberwiseClone()` is a **built-in protected method of the `Object` class in C#**.

This means:

* Every class in C# **inherits it automatically**
* It performs a **shallow copy** of the object

---

# 3. What is the `ICloneable` Interface?

`ICloneable` is a **built-in C# interface** that defines a method used to clone objects.

Namespace:

```
System
```

Definition:

```csharp
public interface ICloneable
{
    object Clone();
}
```

Any class that implements `ICloneable` **must implement the `Clone()` method**.

Example:

```csharp
public class Ticket : ICloneable
{
    public virtual object Clone()
    {
        return this.MemberwiseClone();
    }
}
```


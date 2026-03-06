# Route Assignment A4 – Polymorphism in C#

This assignment extends the Movie Ticket Booking System by applying **polymorphism**, including method overriding and method overloading.

## Part 1 – Theoretical Concepts

Topics covered include:

- Difference between **static binding and dynamic binding**
- Difference between **method overloading and method overriding**
- Keywords used for overriding:
  - `virtual`
  - `override`
  - `base`

## Part 2 – Practical Task

### Applying Polymorphism

The ticket system is updated to make it more flexible and extensible.

### Ticket Class Improvements

- `PrintTicket()` method for displaying ticket information
- Two overloaded versions of `SetPrice()`:
  - One that sets price directly
  - One that calculates price using a base price and multiplier

### Child Class Behavior

Each ticket type provides its own implementation of `PrintTicket()`:

- **StandardTicket** – Prints seat number
- **VIPTicket** – Prints lounge access and service fee
- **IMAXTicket** – Prints whether the ticket is 3D

### Cinema Class Update

`PrintAllTickets()` now loops through the ticket array and calls `PrintTicket()` polymorphically.


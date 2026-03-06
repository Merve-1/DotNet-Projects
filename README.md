# Route Assignment A3 – Inheritance & Object Relationships

This assignment refactors the Movie Ticket Booking System using **inheritance, composition, and object relationships**.

## Part 1 – Theoretical Concepts

Topics covered include:

- Types of object relationships:
  - Inheritance
  - Association
  - Aggregation
  - Composition
  - Dependency
- Access modifiers behavior across assemblies
- Differences between:
  - `protected internal`
  - `private protected`
- Understanding the `sealed` keyword in classes and methods

## Part 2 – Practical Task

### Refactoring the Ticket System

The system is redesigned using inheritance.

### Base Class

`Ticket` class contains:

- `MovieName`
- `Price`
- `TicketId` (auto-increment)
- `PriceAfterTax` computed property

Methods include:

- `ToString()` override for printing ticket information
- `GetTotalTickets()` static method

### Child Classes

Three ticket types inherit from `Ticket`:

- **StandardTicket**
  - Adds `SeatNumber`

- **VIPTicket**
  - Adds `LoungeAccess`
  - Adds fixed `ServiceFee`

- **IMAXTicket**
  - Adds `Is3D`
  - Adjusts ticket price if 3D

Each class overrides `ToString()`.

### Cinema Class

The cinema system includes:

- `CinemaName`
- `Projector` object (composition)
- Ticket storage (up to 20 tickets)

Methods:

- `AddTicket()`
- `PrintAllTickets()`
- `OpenCinema()`
- `CloseCinema()`

### Application Flow

The program:

1. Creates a cinema
2. Opens the cinema
3. Creates different ticket types
4. Adds them to the cinema
5. Prints all tickets
6. Closes the cinema

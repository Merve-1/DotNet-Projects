# Route Assignment A1 – OOP Basics in C#

This assignment introduces the fundamental concepts of **Object-Oriented Programming (OOP)** in C# through theoretical questions and a small practical project.

## Part 1 – Theoretical Concepts

This section covers the following topics:

- Difference between **class and struct** with examples
- Difference between **public and private access modifiers**
- Steps to create and use a **Class Library in Visual Studio**
- Understanding **what a class library is and why it is used**

## Part 2 – Practical Task

### Movie Ticket Booking System (Console Application)

A simple console-based system that simulates booking a movie ticket.

#### Features

- `TicketType` enum representing:
  - Standard
  - VIP
  - IMAX

- `SeatLocation` struct representing:
  - Seat Row
  - Seat Number

- `Ticket` class containing:
  - Movie name
  - Ticket type
  - Seat location
  - Ticket price (private)

#### Implemented Methods

- **CalcTotal()** – Calculates the ticket price after applying tax
- **ApplyDiscount()** – Applies a valid discount to the ticket price
- **PrintTicket()** – Displays ticket information


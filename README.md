# Route Assignment A2 – Encapsulation & Advanced Class Design

This assignment improves the Movie Ticket Booking System by applying **encapsulation, properties, indexers, and static members**.

## Part 1 – Theoretical Concepts

Topics covered include:

- Encapsulation problems and how to fix them
- Difference between **fields and properties**
- **Read-only calculated properties**
- Understanding **indexers in C#**
- Difference between **static and instance members**

## Part 2 – Practical Task

### Enhancing the Movie Ticket Booking System

The system from Assignment 01 is extended with better design and new functionality.

### Improvements

#### Encapsulation
The `Ticket` class now uses **properties with validation**:

- `MovieName` cannot be empty
- `Price` must be greater than 0
- `Seat` and `Type` use previously defined types

#### Calculated Property

- `PriceAfterTax` calculates ticket price including **14% tax**.

#### Static Members

- `ticketCounter` to track total tickets created
- `TicketId` generated automatically
- `GetTotalTicketsSold()` method

#### Cinema Class

A `Cinema` class manages up to **20 tickets** and provides:

- Indexer access to tickets
- Searching tickets by movie name
- Adding tickets to available slots

#### Utility Class

`BookingHelper` static class provides:

- `CalcGroupDiscount()` for group bookings
- `GenerateBookingReference()` for unique booking IDs


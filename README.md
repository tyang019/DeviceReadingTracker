# Device Reading Tracker

A small C#/.NET console application for recording, validating, and analyzing simulated device readings.

This project was created to practice software development concepts including object-oriented programming, input validation, exception handling, debugging, and automated unit testing.

## Features

- Record simulated device readings
- Validate readings between 0 and 100
- Classify readings as Pass or Review
- Store a timestamp for each reading
- Calculate average reading values
- View recorded readings and device summaries
- Toggle device online and offline status
- Handle invalid and out-of-range input
- Run automated unit tests with xUnit

## Technologies

- C#
- .NET
- xUnit
- Visual Studio
- Git
- GitHub

## Software Development Concepts

This project demonstrates:

- Object-oriented programming
- Classes and objects
- Properties and constructors
- Encapsulation
- Enums
- `List<T>` collections
- Methods
- Variables and data types
- Conditional statements
- `while` and `for` loops
- `switch` statements
- Exception handling
- Input validation
- LINQ
- Lambda expressions
- Debugging with breakpoints
- Unit testing
- Arrange-Act-Assert testing pattern

## Project Structure

```text
DeviceReadingTracker
├── Device.cs
├── Reading.cs
├── ReadingStatus.cs
└── Program.cs

DeviceTracker.Tests
└── DeviceTests.cs
```

## Automated Testing

The project includes six xUnit tests covering:

1. Adding a valid reading
2. Rejecting an invalid reading
3. Classifying an in-range reading as Pass
4. Classifying an out-of-range reading as Review
5. Calculating the average of recorded readings
6. Rejecting NaN readings

Run the tests with:

```bash
dotnet test
```
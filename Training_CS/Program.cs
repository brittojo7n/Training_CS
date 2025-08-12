using System;

public class Program
{
    public static void Main(string[] args)
    {
        //## 1. Integral Types (for whole numbers)
        int pageCount = 42;          // The most common type for whole numbers.
        long worldPopulation = 8_100_000_000L; // For very large whole numbers. Note the 'L'.
        short smallNumber = 32000;   // For smaller whole numbers.
        byte age = 99;               // For small, non-negative numbers (0 to 255).

        Console.WriteLine("## Integral Types ##");
        Console.WriteLine($"int (Page Count): {pageCount}");
        Console.WriteLine($"long (World Population): {worldPopulation}");
        Console.WriteLine($"short (Small Number): {smallNumber}");
        Console.WriteLine($"byte (Age): {age}");

        Console.WriteLine("\n----------------------------------------\n");

        //## 2. Floating-Point Types (for decimal numbers)
        float itemPrice = 19.95F;      // For numbers with decimals. Note the 'F'.
        double pi = 3.1415926535;   // The default for decimals, offers more precision.
        decimal accountBalance = 1500.85M; // For high-precision financial calculations. Note the 'M'.

        Console.WriteLine("## Floating-Point Types ##");
        Console.WriteLine($"float (Item Price): {itemPrice}");
        Console.WriteLine($"double (Value of Pi): {pi}");
        Console.WriteLine($"decimal (Account Balance): {accountBalance}");

        Console.WriteLine("\n----------------------------------------\n");

        //## 3. Character and Text Types
        char grade = 'A';              // A single character, in single quotes.
        string greeting = "Hello, World!"; // A sequence of characters (text), in double quotes.

        Console.WriteLine("## Character and Text Types ##");
        Console.WriteLine($"char (Grade): {grade}");
        Console.WriteLine($"string (Greeting): \"{greeting}\"");

        Console.WriteLine("\n----------------------------------------\n");

        //## 4. Boolean Type
        bool isCompleted = true;       // Represents a simple true or false value.

        Console.WriteLine("## Boolean Type ##");
        Console.WriteLine($"Is the task completed? {isCompleted}");

        //## 5. Object Type
        object objA = new object();
        object objB = new object();
        Console.WriteLine("\n----------------------------------------\n");
        objA = objB;
        objB = 123;
        Console.WriteLine($"objA: {objA} and objB: {objB}");
        objB = objA;
        objA = 590;
        Console.WriteLine($"objA: {objA} and objB: {objB}");
        Console.WriteLine("## Object Type ##");
        Console.WriteLine(objA == objB ? $"{objA} and {objB} are the same object." : $"{objA} and {objB} are different objects.");
        
    }
}
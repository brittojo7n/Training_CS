using System;

// A reference type (class). Objects of this type will be stored on the Heap.
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth = DateTime.Today; // Default value for DateTime is the current date and time.

    // Change 'DOB' from a field to a property so it can access 'DateOfBirth' safely
    public string DOB => DateOfBirth.ToString("dd/MM/yyyy");
}

public class Program
{
    private static int exit;

    public static void Main(string[] args)
    {
        while (true)
        {
            //## 1. Integral Types (for whole numbers)
            int pageCount = 42;          // The most common type for whole numbers.
            long worldPopulation = 8100000000L; // For very large whole numbers. Note the 'L'.
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

            Person person = new Person { Name = "Anya", Age = 0 };

            Console.WriteLine($"Name: {person.Name}\nAge: {person.Age}\nDOB: {person.DOB}");

            Console.WriteLine("## Arithmetic Operations ##");

            int a = 21;
            int b = 5;

            int sum = a + b;
            int difference = a - b;
            int product = a * b;
            int quotient = a / b;
            int remainder = a % b;

            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"Addition (a + b): {sum}");
            Console.WriteLine($"Subtraction (a - b): {difference}");
            Console.WriteLine($"Multiplication (a * b): {product}");
            Console.WriteLine($"Division (a / b): {quotient}");
            Console.WriteLine($"Modulus/Remainder (a % b): {remainder}");

            Console.WriteLine("\n----------------------------------------\n");

            Console.WriteLine("## Logical Operations ##");

            bool condition1 = true;
            bool condition2 = false;

            bool andResult = condition1 && condition2;
            bool orResult = condition1 || condition2;
            bool notResult = !condition1;

            Console.WriteLine($"condition1 = {condition1}, condition2 = {condition2}");
            Console.WriteLine($"AND (condition1 && condition2): {andResult}");
            Console.WriteLine($"OR (condition1 || condition2): {orResult}");
            Console.WriteLine($"NOT (!condition1): {notResult}");

            Console.WriteLine("## Basic Increment and Decrement ##");
            int counter = 10;
            Console.WriteLine($"Initial counter: {counter}");

            counter++; // Increment by 1
            Console.WriteLine($"After counter++: {counter}");

            counter--; // Decrement by 1
            Console.WriteLine($"After counter--: {counter}");

            Console.WriteLine("\n----------------------------------------\n");

            Console.WriteLine("## Postfix vs. Prefix Demonstration ##");

            // Postfix: Assigns first, then increments.
            int postfixCounter = 5;
            int postfixResult = postfixCounter++;
            Console.WriteLine("Postfix (result = counter++):");
            Console.WriteLine($"  Result received: {postfixResult}"); // Gets the original value
            Console.WriteLine($"  Counter is now: {postfixCounter}");   // Then the counter changes

            // Prefix: Increments first, then assigns.
            int prefixCounter = 5;
            int prefixResult = ++prefixCounter;
            Console.WriteLine("\nPrefix (result = ++counter):");
            Console.WriteLine($"  Result received: {prefixResult}"); // Gets the new value
            Console.WriteLine($"  Counter is now: {prefixCounter}");   // The counter has already changed
            Console.WriteLine($"a = {a} and b = {b}");

            a += 5; // This is equivalent to a = a + 5;
            b -= 2; // This is equivalent to b = b - 2;
            Console.WriteLine($"a += 5: {a} and b -= 2: {b}");

            while (true)
            {
                Console.WriteLine("\nExit the program? (yes/no): ");
                string exit = Console.ReadLine().ToLower();
                switch (exit)
                {
                    case "yes":
                        System.Environment.Exit(0);
                        break;

                    case "y":
                        System.Environment.Exit(0);
                        break;

                    case "no":
                        Console.WriteLine("Conitnuing...");
                        break;

                    case "n":
                        Console.WriteLine("Conitnuing...");
                        break;

                    default:
                        Console.WriteLine("Invalid Input!");
                        continue;
                }
                break;
            }
        }
    }
}
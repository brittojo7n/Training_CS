using System;

namespace Training_CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isAlive = true;
            Dispatcher dispatch = new Dispatcher();
            ESwap swap = new ESwap();
            Factorial fact = new Factorial();
            Override ovride = new Override();
            BankingSystem bank = new BankingSystem();
            Car myCar = new Car("Toyota", "Supra", 2020);

            string[] menu = {
                "1. Dispatcher",
                "2. ESwap",
                "3. Factorial",
                "4. Override",
                "5. Banking System",
                "6. Car Concept",
                "7. Exit"
            };
            do
            {
                foreach (string item in menu)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n\nPick a choice: ");
                string userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out int choice))
                {
                    Console.WriteLine("\nInvalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        dispatch.Vehicle("Truck");
                        dispatch.Vehicle("Truck", "Sully Morgan");
                        dispatch.Vehicle("Truck", 42);
                        break;
                    case 2: 
                        swap.Start();
                        break;
                    case 3:
                        Console.WriteLine("\nEnter a number: ");
                        userInput = Console.ReadLine();

                        if (!int.TryParse(userInput, out int num))
                        {
                            Console.WriteLine("\nInvalid input! Please enter a number.");
                            continue;
                        }
                        fact.Fact(num);
                        break;
                    case 4:
                        ovride.Start();
                        break;
                    case 5:
                        bank.Start();
                        break;
                    case 6:
                        Console.WriteLine();
                        myCar.Accelerate(50);
                        myCar.Accelerate(30);
                        myCar.Brake(20);
                        myCar.DisplayStatus();
                        break;
                    case 7:
                        isAlive = false;
                        Console.WriteLine("\n\nExiting...");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice! Please select a valid option.");
                        break;
                }
            } while (isAlive);
        }
    }
}
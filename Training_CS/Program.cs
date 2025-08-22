using System;
using System.IO;
using Training_CS.Classes;

namespace Training_CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isAlive = true;
            Dispatcher dispatch = new Dispatcher("Scania", 44, "Vladimir Glebov");
            ESwap swap = new ESwap();
            Factorial fact = new Factorial();
            Override ovride = new Override();
            BankingSystem bank = new BankingSystem();
            Car myCar = new Car("Toyota", "Supra", 2020);
            Smartphone myPhone = new Smartphone("Samsung Galaxy S24 Ultra", 20);
            Laptop myLaptop = new Laptop("ASUS TUF GAMING A15", 50);
            PdfGen pdf = new PdfGen();

            string[] menu = {
                "1. Dispatcher",
                "2. ESwap",
                "3. Factorial",
                "4. Override",
                "5. Banking System",
                "6. Cars",
                "7. Devices",
                "8. PDF Generation",
                "9. Exit"
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
                        dispatch.Vehicle();
                        dispatch.Vehicle("Dimitri Rascalov");
                        dispatch.Vehicle(28);
                        dispatch.Vehicle();
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
                        Console.WriteLine(fact.Fact(num));
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
                        do
                        {
                            Console.WriteLine("\n1. Get Status of Phone\n2. Get Status of Laptop\n3. Charge device\n4. Back\nChoose an option:");
                            userInput = Console.ReadLine();
                            if (!int.TryParse(userInput, out int subChoice))
                            {
                                Console.WriteLine("\nInvalid input! Please enter a number.");
                                continue;
                            }
                            switch (subChoice)
                            {
                                case 1:
                                    myPhone.TurnOn();
                                    Console.WriteLine(myPhone.GetStatus());
                                    break;
                                case 2:
                                    myLaptop.TurnOn();
                                    Console.WriteLine(myLaptop.GetStatus());
                                    break;
                                case 3:
                                    IChargeable chargePhone = myPhone;
                                    IChargeable chargeLaptop = myLaptop;
                                    if(chargePhone.BatteryLevel < 100)
                                        chargePhone.Charge();
                                    if (chargeLaptop.BatteryLevel < 100)
                                        chargeLaptop.Charge();
                                    Console.WriteLine($"\n{myPhone.GetStatus()}");
                                    Console.WriteLine(myLaptop.GetStatus());
                                    break;
                                case 4:
                                    isAlive = false;
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid choice! Please select a valid option.");
                                    break;
                            }
                        } while (isAlive);
                        isAlive = true;
                        break;
                    case 8:
                        pdf.Generate($"{Directory.GetCurrentDirectory()}\\JobAppForm.pdf");
                        break;
                    case 9:
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
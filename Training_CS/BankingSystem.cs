using System;

namespace Training_CS
{
    internal class BankingSystem
    {
        public void Start()
        {
            decimal accountBalance = 0.00M;
            string message, accountNum, accountPin, accountName;
            string[] account = { "1001", "1002", "1003" };
            string[] pin = { "9452", "1111", "2000" };
            string[] name = { "Dave", "Sam", "Frank" };
            decimal[] balance = { 2.00M, 5.00M, 10.00M };
            bool isValid = false;
            bool isAccount = false;
            accountName = "";

            do
            {
                Console.WriteLine("\nEnter the Account Number: ");
                accountNum = Console.ReadLine();

                for (int i = 0; i < account.Length; i++)
                {
                    if (account[i] == accountNum)
                    {
                        isAccount = true;
                        Console.WriteLine("\nEnter the PIN: ");
                        accountPin = Console.ReadLine();
                        if (pin[i] == accountPin)
                        {
                            accountName = name[i];
                            accountBalance = balance[i];
                            isValid = true;
                            break;
                        }
                    }
                }
                if (!isValid && isAccount)
                {
                    Console.WriteLine("\nWrong Password!");
                }
                else if (!isAccount)
                {
                    Console.WriteLine("\nAccount doesn't exist!");
                }
            } while (!isValid);

            while (isValid)
            {
                Console.WriteLine("\n\n1. Check Account Balance\n2. Add/Remove funds\n3. Account Details\n4. Exit\n\nEnter a choice:");
                int choice;
                string userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out choice)) Console.WriteLine("Invalid input! Please enter a number.");

                switch (choice)
                {
                    case 1:
                        if (accountBalance > 0)
                        {
                            message = $"\nYour current balance is ${accountBalance}";
                        }
                        else
                        {
                            message = $"\nYour current balance is ${accountBalance}. Try adding some funds.";
                        }
                        Console.WriteLine(message);
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine("\nEnter funds to add to your account (negative values to remove): ");
                            decimal funds = decimal.Parse(Console.ReadLine());
                            if (accountBalance + funds < 0)
                            {
                                message = "\nInsufficient funds! Cannot remove more than current balance.";
                            }
                            else
                            {
                                accountBalance += funds;
                                message = $"\n${funds} have been added.\nYour new balance is ${accountBalance}";
                            }

                            Console.WriteLine(message);
                            Console.WriteLine("\nContinue adding? \nType anything other than \"y\" or \"yes\" to go back...");
                            userInput = Console.ReadLine();
                        } while (userInput.ToLower() == "yes" || userInput.ToLower() == "y");
                        break;

                    case 3:
                        Console.WriteLine($"\nAccount Number: {accountNum}\nAccount Name: {accountName}\nAccount Balance: ${accountBalance}");
                        break;

                    case 4:
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
                                    Console.WriteLine("\nConitnuing...");
                                    break;

                                case "n":
                                    Console.WriteLine("\nConitnuing...");
                                    break;

                                default:
                                    Console.WriteLine("\nInvalid Input!");
                                    break;
                            }
                            break;
                        }
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }
            }
        }
    }
}

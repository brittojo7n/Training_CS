using System;
using System.Collections.Generic;

namespace Training_CS
{
    class AccountDetails
    {
        public string Pin { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<string> TransactionHistory { get; set; }
        public HashSet<string> LoginLocations { get; set; }

        public AccountDetails()
        {
            TransactionHistory = new List<string>();
            LoginLocations = new HashSet<string>();
        }
    }

    internal class BankingSystem
    {
        static Random random = new Random();

        public void Start()
        {
            var accounts = new Dictionary<string, AccountDetails>
            {
                { "1001", new AccountDetails { Pin = "9452", Name = "Dave", Balance = 2.00M } },
                { "1002", new AccountDetails { Pin = "1111", Name = "Sam", Balance = 5.00M } },
                { "1003", new AccountDetails { Pin = "2000", Name = "Frank", Balance = 10.00M } }
            };

            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };
            decimal accountBalance = 0.00M;
            int citiesRandom;
            string message, accountNum, accountPin, accountName, exitPrompt;
            bool isValid = false;
            bool isExit = false;
            accountName = "";

            while (!isExit)
            {
                do
                {
                    Console.WriteLine("\nEnter the Account Number: ");
                    accountNum = Console.ReadLine();

                    if (accounts.TryGetValue(accountNum, out AccountDetails details))
                    {
                        Console.WriteLine("\nEnter the PIN: ");
                        accountPin = Console.ReadLine();
                        if (details.Pin == accountPin)
                        {
                            citiesRandom = random.Next(cities.Length);
                            details.LoginLocations.Add(cities[citiesRandom]);
                            accountName = details.Name;
                            accountBalance = details.Balance;
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Account Number or PIN.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Account Number.");
                    }
                } while (!isValid);

                while (isValid)
                {
                    string[] menuOptions = {
                    "Check Account Balance",
                    "Add/Remove funds",
                    "Account Details",
                    "View Transaction History",
                    "View Login Locations",
                    "Logout"
                };

                    Console.WriteLine("\n--- Main Menu ---");
                    for (int i = 0; i < menuOptions.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {menuOptions[i]}");
                    }
                    Console.Write("\nEnter a choice: ");

                    int choice;
                    string userInput = Console.ReadLine();

                    if (!int.TryParse(userInput, out choice))
                    {
                        Console.WriteLine("Invalid input! Please enter a number.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            message = $"\nYour current balance is ${accountBalance}";
                            Console.WriteLine(message);
                            break;

                        case 2:
                            Console.WriteLine("\nEnter funds to add to your account (negative values to remove): ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal funds) && funds != 0)
                            {
                                string transactionRecord;
                                if (accountBalance + funds < 0)
                                {
                                    message = "\nInsufficient funds! Cannot remove more than current balance.";
                                    transactionRecord = $"Failed withdrawal attempt of ${-funds}";
                                }
                                else
                                {
                                    accountBalance += funds;
                                    accounts[accountNum].Balance = accountBalance;

                                    if (funds > 0)
                                    {
                                        transactionRecord = $"Deposited: ${funds} on {DateTime.Now:dd/MM/yyyy}";
                                    }
                                    else
                                    {
                                        transactionRecord = $"Withdrew: ${-funds} on {DateTime.Now:dd/MM/yyyy}";
                                    }
                                    message = $"\nTransaction complete. Your new balance is ${accountBalance}";
                                }
                                accounts[accountNum].TransactionHistory.Add(transactionRecord);
                                Console.WriteLine(message);
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount entered.");
                            }
                            break;

                        case 3:
                            Console.WriteLine($"\nAccount Number: {accountNum}\nAccount Name: {accountName}\nAccount Balance: ${accountBalance}");
                            break;

                        case 4:
                            Console.WriteLine("\n--- Transaction History ---");
                            List<string> history = accounts[accountNum].TransactionHistory;
                            if (history.Count == 0)
                            {
                                Console.WriteLine("No transactions have been made yet.");
                            }
                            else
                            {
                                foreach (var record in history)
                                {
                                    Console.WriteLine(record);
                                }
                            }
                            break;

                        case 5:
                            Console.WriteLine("\n--- Unique Login Locations ---");
                            HashSet<string> locations = accounts[accountNum].LoginLocations;
                            foreach (var location in locations)
                            {
                                Console.WriteLine($"- {location}");
                            }
                            break;

                        case 6:
                            Console.WriteLine("\n Do you want to Log out? (y/n)");
                            exitPrompt = Console.ReadLine();
                            if (exitPrompt.ToLower() == "y" || exitPrompt.ToLower() == "yes") isValid = false;
                            break;

                        default:
                            Console.WriteLine("\nInvalid choice.");
                            break;
                    }
                }
                
                if (!isValid)
                {
                    Console.WriteLine("\nExit? (y/n): ");
                    exitPrompt = Console.ReadLine();
                    if (exitPrompt.ToLower() == "y" || exitPrompt.ToLower() == "yes")
                    {
                        isExit = true;
                        Console.WriteLine("\nThank you for using the Banking System. Goodbye!");
                    }
                    else
                    {
                        Console.WriteLine("\n\n-- Login Menu --");
                    }
                }
            }
        }
    }
}

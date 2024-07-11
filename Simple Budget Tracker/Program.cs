using System;
using System.Collections.Generic;

class BudgetTracker
{
    static List<Transaction> transactions = new List<Transaction>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Budget Tracker:");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View Transactions");
            Console.WriteLine("4. View Balance");
            Console.WriteLine("5. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    AddTransaction("Income");
                    break;
                case "2":
                    AddTransaction("Expense");
                    break;
                case "3":
                    ViewTransactions();
                    break;
                case "4":
                    ViewBalance();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddTransaction(string type)
    {
        Console.Write($"Enter {type} amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            transactions.Add(new Transaction { Type = type, Amount = amount });
        }
        else
        {
            Console.WriteLine("Invalid amount. Press Enter to try again.");
            Console.ReadLine();
        }
    }

    static void ViewTransactions()
    {
        Console.Clear();
        Console.WriteLine("Transactions:");
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{transaction.Type}: {transaction.Amount:C}");
        }
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }

    static void ViewBalance()
    {
        decimal balance = 0;
        foreach (var transaction in transactions)
        {
            if (transaction.Type == "Income")
            {
                balance += transaction.Amount;
            }
            else if (transaction.Type == "Expense")
            {
                balance -= transaction.Amount;
            }
        }
        Console.WriteLine($"\nTotal Balance: {balance:C}");
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}

class Transaction
{
    public string Type { get; set; }
    public decimal Amount { get; set; }
}

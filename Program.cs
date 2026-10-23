
using System;

namespace MiniBankingSystem
{
    // Class 1: Represents a bank account
    class BankAccount
    {
        // Property: stores the account balance
        public decimal Balance { get; private set; }

        // Constructor: sets the starting balance
        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        // Method 1: Check balance
        public void CheckBalance()
        {
            Console.WriteLine($"\nYour balance is: UGX {Balance:N0}");
        }

        // Method 2: Deposit money
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please enter a valid deposit amount.");
            }
            else
            {
                Balance += amount;
                Console.WriteLine("Deposit successful!");
                Console.WriteLine($"Amount deposited: UGX {amount:N0}");
                Console.WriteLine($"New balance: UGX {Balance:N0}");
            }
        }

        // Method 3: Withdraw money
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please enter a valid withdrawal amount.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine("Withdrawal successful!");
                Console.WriteLine($"Amount withdrawn: UGX {amount:N0}");
                Console.WriteLine($"Remaining balance: UGX {Balance:N0}");
            }
        }
    }

    // Class 2: Controls the banking application
    class Program
    {
        static void Main(string[] args)
        {
            // Create a BankAccount object
            BankAccount account = new BankAccount(1000m);

            bool running = true;

            Console.WriteLine("==================================");
            Console.WriteLine("     WELCOME TO MINI BANKING");
            Console.WriteLine("==================================");

            while (running)
            {
                Console.WriteLine("\n========== BANK MENU ==========");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Exit");
                Console.WriteLine("===============================");

                Console.Write("Choose an option (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        account.CheckBalance();
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: UGX ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            account.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter a number.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter amount to withdraw: UGX ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                        {
                            account.Withdraw(withdrawalAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter a number.");
                        }
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Thank you for using Mini Banking!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1-4.");
                        break;
                }
            }

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }
    }
}

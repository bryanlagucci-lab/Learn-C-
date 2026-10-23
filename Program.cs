
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MINIBANK
{
    public class BankAccount
    {
        // 1. Static field: shared by all account objects
        private static int totalAccountsOpened = 0;

        // 2. Static constructor: runs once when the class is initialized
        static BankAccount()
        {
            Console.WriteLine(
                "MINI Bank account system has been initialized."
            );
        }

        // 3. Private instance fields: each object has its own values
        private string AccountNumber;
        private string AccountName;
        private decimal Balance;
        private bool paysTax;

        // Read-only access to account information
        public string GetAccountNumber()
        {
            return AccountNumber;
        }

        public string GetAccountName()
        {
            return AccountName;
        }

        public bool PaysTax()
        {
            return paysTax;
        }

        // 4. Four-parameter constructor
        public BankAccount(
            string acc_no,
            string acc_name,
            decimal bal,
            bool ptax)
        {
            AccountNumber = acc_no;
            AccountName = acc_name;
            Balance = bal;
            paysTax = ptax;

            totalAccountsOpened++;
        }

        // 5. Three-parameter overloaded constructor
        public BankAccount(
            string acc_no,
            string acc_name,
            decimal bal)
            : this(acc_no, acc_name, bal, false)
        {
        }

        // 6. Two-parameter overloaded constructor
        // Default starting balance is UGX 1,000,000
        public BankAccount(string acc_no, string acc_name)
            : this(acc_no, acc_name, 1000000m, false)
        {
        }

        // 7. Instance method: deposit money
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(
                    "Deposit amount must be greater than zero."
                );
                return;
            }

            Balance += amount;

            Console.WriteLine("Deposit successful!");
            Console.WriteLine(
                $"Deposited: {FormatCurrency(amount)}"
            );
            Console.WriteLine(
                $"New balance: {FormatCurrency(Balance)}"
            );
        }

        // 8. Instance method: withdraw money
        // Returns the amount withdrawn, or 0 if unsuccessful
        public decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(
                    "Withdrawal amount must be greater than zero."
                );
                return 0m;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return 0m;
            }

            Balance -= amount;

            Console.WriteLine("Withdrawal successful!");
            Console.WriteLine(
                $"Withdrawn: {FormatCurrency(amount)}"
            );
            Console.WriteLine(
                $"Remaining balance: {FormatCurrency(Balance)}"
            );

            return amount;
        }

        // 9. Safely retrieve the private balance
        public decimal GetBalance()
        {
            return Balance;
        }

        // 10. Display account details
        public void DisplayAccount()
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Account Name   : {AccountName}");
            Console.WriteLine(
                $"Balance        : {FormatCurrency(Balance)}"
            );
            Console.WriteLine(
                $"Pays Tax       : {(paysTax ? "Yes" : "No")}"
            );
            Console.WriteLine("--------------------------------");
        }

        // 11. Static method: get total accounts
        public static int GetTotalAccounts()
        {
            return totalAccountsOpened;
        }

        // 12. Static method: format money as Ugandan shillings
        public static string FormatCurrency(decimal amount)
        {
            return "UGX " + amount.ToString(
                "N0",
                CultureInfo.InvariantCulture
            );
        }
    }

    class Program
    {
        static void Main()
        {
            // Stores all account objects created during this session
            List<BankAccount> accounts = new List<BankAccount>();

            bool running = true;

            Console.WriteLine("\n==================================");
            Console.WriteLine("       MINI BANK MANAGEMENT");
            Console.WriteLine("==================================");

            while (running)
            {
                Console.WriteLine("\n============= MAIN MENU =============");
                Console.WriteLine("1. Open a new account");
                Console.WriteLine("2. View all accounts");
                Console.WriteLine("3. Check account balance");
                Console.WriteLine("4. Deposit money");
                Console.WriteLine("5. Withdraw money");
                Console.WriteLine("6. View total accounts");
                Console.WriteLine("7. Exit");
                Console.WriteLine("=====================================");

                Console.Write("Choose an option (1-7): ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        OpenAccount(accounts);
                        break;

                    case "2":
                        ViewAllAccounts(accounts);
                        break;

                    case "3":
                        BankAccount balanceAccount =
                            FindAccount(accounts);

                        if (balanceAccount != null)
                        {
                            Console.WriteLine(
                                $"Current balance: {BankAccount.FormatCurrency(
                                    balanceAccount.GetBalance())}"
                            );
                        }
                        break;

                    case "4":
                        BankAccount depositAccount =
                            FindAccount(accounts);

                        if (depositAccount != null)
                        {
                            decimal depositAmount =
                                ReadAmount("Enter deposit amount: UGX ");

                            depositAccount.Deposit(depositAmount);
                        }
                        break;

                    case "5":
                        BankAccount withdrawalAccount =
                            FindAccount(accounts);

                        if (withdrawalAccount != null)
                        {
                            decimal withdrawalAmount =
                                ReadAmount("Enter withdrawal amount: UGX ");

                            withdrawalAccount.Withdraw(withdrawalAmount);
                        }
                        break;

                    case "6":
                        Console.WriteLine(
                            $"Total accounts opened: {BankAccount.GetTotalAccounts()}"
                        );
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine(
                            "Thank you for banking with MRU Bank!"
                        );
                        break;

                    default:
                        Console.WriteLine(
                            "Invalid choice. Select an option from 1 to 7."
                        );
                        break;
                }
            }

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }

        // Create and store a new BankAccount object
        static void OpenAccount(List<BankAccount> accounts)
        {
            Console.Write("\nEnter account number: ");
            string number = Console.ReadLine() ?? "";

            Console.Write("Enter account holder's name: ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(number) ||
                string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(
                    "Account number and name cannot be empty."
                );
                return;
            }

            // Prevent duplicate account numbers
            foreach (BankAccount existing in accounts)
            {
                if (existing.GetAccountNumber()
                    .Equals(number, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                        "That account number already exists."
                    );
                    return;
                }
            }

            Console.WriteLine("\nChoose account setup:");
            Console.WriteLine("1. Default balance (UGX 1,000,000; no tax)");
            Console.WriteLine("2. Enter starting balance (no tax)");
            Console.WriteLine("3. Enter starting balance and tax status");
            Console.Write("Choice: ");

            string setupChoice = Console.ReadLine() ?? "";
            BankAccount account;

            switch (setupChoice)
            {
                case "1":
                    // Calls the two-parameter constructor
                    account = new BankAccount(number, name);
                    break;

                case "2":
                    // Calls the three-parameter constructor
                    decimal balance = ReadAmount(
                        "Enter starting balance: UGX "
                    );

                    account = new BankAccount(number, name, balance);
                    break;

                case "3":
                    // Calls the four-parameter constructor
                    decimal taxBalance = ReadAmount(
                        "Enter starting balance: UGX "
                    );

                    Console.Write("Does the account pay tax? (yes/no): ");
                    string taxChoice =
                        (Console.ReadLine() ?? "").Trim();

                    if (!taxChoice.Equals(
                        "yes", StringComparison.OrdinalIgnoreCase) &&
                        !taxChoice.Equals(
                        "no", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(
                            "Invalid tax choice. Enter yes or no."
                        );
                        return;
                    }

                    bool taxStatus = taxChoice.Equals(
                        "yes", StringComparison.OrdinalIgnoreCase);

                    account = new BankAccount(
                        number, name, taxBalance, taxStatus
                    );
                    break;

                default:
                    Console.WriteLine("Invalid setup choice.");
                    return;
            }

            accounts.Add(account);

            Console.WriteLine("\nAccount created successfully!");
            account.DisplayAccount();
        }

        // Display every account in the list
        static void ViewAllAccounts(List<BankAccount> accounts)
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts have been opened yet.");
                return;
            }

            Console.WriteLine("\n========== ALL ACCOUNTS ==========");

            foreach (BankAccount account in accounts)
            {
                account.DisplayAccount();
            }

            Console.WriteLine(
                $"Total accounts: {BankAccount.GetTotalAccounts()}"
            );
        }

        // Find an account using its account number
        static BankAccount FindAccount(List<BankAccount> accounts)
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts available. Open an account first.");
                return null;
            }

            Console.Write("Enter account number: ");
            string number = Console.ReadLine() ?? "";

            foreach (BankAccount account in accounts)
            {
                if (account.GetAccountNumber()
                    .Equals(number, StringComparison.OrdinalIgnoreCase))
                {
                    return account;
                }
            }

            Console.WriteLine("Account not found.");
            return null;
        }

        // Safely read a decimal amount from the user
        static decimal ReadAmount(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                if (decimal.TryParse(
                    Console.ReadLine(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal amount) && amount >= 0)
                {
                    return amount;
                }

                Console.WriteLine(
                    "Enter a valid non-negative number."
                );
            }
        }
    }
}

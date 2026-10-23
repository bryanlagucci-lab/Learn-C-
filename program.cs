using System;

namespace MRUBANK
{

    public class Program
    {
        // static field

        private static int totalAccountsOpened = 0;
        // static constructor

        static BankAccount()
        {
            Console.WriteLine("Our MRU account system has been initialised"); 
        }
        // instance (object) fields

        private string AccountNumber;
        
        private string AccountName;

        private decimal Balance;

        private bool paysTax;

        // Parameterized constructor
        public BankAccount(string acc_no, string acc_name, decimal bal, bool ptax)
        {
            this.AccountNumber = acc_no;
            this.AccountName = acc_name;
            this.Balance = bal;
            this.paysTax = ptax;
            totalAccountsOpened++;
        }
        
        // overloaded constructor
        public BankAccount(string acc_no, string acc_name, decimal bal)// 2 parameters
        {
            this.AccountNumber = acc_no;
            this.AccountName = acc_name;
            Balance = 1000000; // default value
            totalAccountsOpened++;
        }

        // instance methods
        public void Deposit(decimal amount)// changes the balance of the account (object's balance)
        {
            Balance += amount; // Balance = Balance + amount
            
        }
        public decimal Withdraw(decimal amount)
        {
            // Validation: Check if the withdrawal amount is less than or equal to the current balance
            if (amount <= Balance)
            {
                Balance -= amount; // Deduct the withdrawal amount from the balance     
                return amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
                return Balance; // Return the current balance if withdrawal is not possible
            }
        }
        
        // exposes private / Encapsulated field safely. Instance method to get the balance of the account
        public decimal GetBalance()
        {
            return Balance;
        }
         
        public static int GetTotalAccounts()
        {
            return totalAccountsOpened;
        } 
                
    }

    class Program
    {
        public static void Main()
        {
            BankAccount account_001 = new BankAccount("0012026AB", "MR BRYAN");
            Console.WriteLine(BankAccount.FormatCurrency(account_001.GetBalance()));

            BankAccount account_002 = new BankAccount("0023026CD", "MRS SAMANTHA", 500000m, true);
            Console.WriteLine(BankAccount.FormatCurrency(account_002.GetBalance()));
            
        }
    }
}
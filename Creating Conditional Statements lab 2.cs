using System;

namespace SavingsCalculator
{
    // Class representing a savings account
    class Savings
    {
        // Properties
        public decimal Principal { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Duration { get; set; }

        // Constructor
        public Savings(decimal principal, decimal interestRate, decimal duration)
        {
            Principal = principal;
            InterestRate = interestRate;
            Duration = duration;
        }

        // Method to calculate simple interest
        public decimal CalculateInterest()
        {
            return (Principal * InterestRate * Duration) / 100;
        }

        // Method to calculate final balance
        public decimal CalculateFinalBalance()
        {
            return Principal + CalculateInterest();
        }

        // Method to classify the account using IF statement
        public void CheckSavingsLevel()
        {
            if (Principal >= 1000000)
            {
                Console.WriteLine("Savings Level: Large Account");
            }
            else if (Principal >= 500000)
            {
                Console.WriteLine("Savings Level: Medium Account");
            }
            else
            {
                Console.WriteLine("Savings Level: Small Account");
            }
        }

        // Display results
        public void DisplayResults()
        {
            Console.WriteLine("\n===== SAVINGS ACCOUNT DETAILS =====");

            Console.WriteLine($"Principal Amount: {Principal}");
            Console.WriteLine($"Interest Rate: {InterestRate}%");
            Console.WriteLine($"Duration: {Duration} years");

            Console.WriteLine($"Simple Interest: {CalculateInterest()}");
            Console.WriteLine($"Final Balance: {CalculateFinalBalance()}");

            CheckSavingsLevel();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("   WELCOME TO SAVINGS CALCULATOR");
            Console.WriteLine("=================================");


            // WHILE LOOP
            int attempts = 0;

            while (attempts < 3)
            {
                Console.WriteLine("\nAttempt " + (attempts + 1));

                attempts++;
            }


            // DO-WHILE LOOP
            string continueProgram;

            do
            {
                // User input
                Console.Write("\nEnter Principal Amount: ");
                decimal principal = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Interest Rate (%): ");
                decimal interestRate = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Duration (Years): ");
                decimal duration = Convert.ToDecimal(Console.ReadLine());


                // Create Savings Object
                Savings savings = new Savings(
                    principal,
                    interestRate,
                    duration
                );


                // SWITCH STATEMENT
                Console.WriteLine("\nSelect Account Type:");

                Console.WriteLine("1. Basic Account");
                Console.WriteLine("2. Premium Account");
                Console.WriteLine("3. Student Account");

                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You selected Basic Account.");
                        break;

                    case 2:
                        Console.WriteLine("You selected Premium Account.");
                        break;

                    case 3:
                        Console.WriteLine("You selected Student Account.");
                        break;

                    default:
                        Console.WriteLine("Invalid Account Type.");
                        break;
                }


                // Display savings information
                savings.DisplayResults();


                // FOR LOOP
                Console.WriteLine("\nYearly Savings Progress:");

                for (int year = 1; year <= duration; year++)
                {
                    decimal yearlyInterest =
                        (principal * interestRate * year) / 100;

                    decimal balance =
                        principal + yearlyInterest;

                    Console.WriteLine(
                        "Year " + year +
                        " - Balance: " + balance
                    );
                }


                // Ask user whether to continue
                Console.Write("\nDo you want to calculate again? (yes/no): ");

                continueProgram = Console.ReadLine().ToLower();

            }
            while (continueProgram == "yes");


            Console.WriteLine("\nThank you for using the Savings Calculator!");

            Console.ReadKey();
        }
    }
}
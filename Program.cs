using System;

namespace SavingsCalculator
{
    // Class representing the Savings Calculator
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

        // Method to calculate final account balance
        public decimal CalculateFinalBalance()
        {
            return Principal + CalculateInterest();
        }

        // Method to display results
        public void DisplayResults()
        {
            decimal interest = CalculateInterest();
            decimal finalBalance = CalculateFinalBalance();

            Console.WriteLine("\n========== SAVINGS CALCULATOR ==========");
            Console.WriteLine($"Principal Amount : {Principal:C}");
            Console.WriteLine($"Interest Rate    : {InterestRate}%");
            Console.WriteLine($"Duration         : {Duration} years");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Simple Interest  : {interest:C}");
            Console.WriteLine($"Final Balance    : {finalBalance:C}");
            Console.WriteLine("========================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       WELCOME TO SAVINGS CALCULATOR");
            Console.WriteLine("========================================\n");

            // Capture user input
            Console.Write("Enter principal amount: ");
            decimal principal = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter annual interest rate (%): ");
            decimal interestRate = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter duration (years): ");
            decimal duration = Convert.ToDecimal(Console.ReadLine());

            // Create Savings object
            Savings savings = new Savings(
                principal,
                interestRate,
                duration
            );

            // Display calculated results
            savings.DisplayResults();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
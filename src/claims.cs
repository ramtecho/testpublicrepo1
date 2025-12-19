using System;

namespace ClaimsReimbursementApp
{
    class Program
    {
        // Method to calculate reimbursement based on rules
        static decimal CalculateReimbursement(decimal claimAmount, decimal maxLimit, decimal coveragePercent)
        {
            // Ensure coveragePercent is between 0 and 100
            if (coveragePercent < 0 || coveragePercent > 100)
                throw new ArgumentOutOfRangeException(nameof(coveragePercent), "Coverage percent must be between 0 and 100.");

            // Apply coverage percentage
            decimal reimbursable = claimAmount * (coveragePercent / 100);

            // Apply maximum limit
            if (reimbursable > maxLimit)
                reimbursable = maxLimit;

            return reimbursable;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Claims Reimbursement Calculator ===");

                // Get claim amount
                Console.Write("Enter claim amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal claimAmount) || claimAmount <= 0)
                {
                    Console.WriteLine("Invalid claim amount. Must be a positive number.");
                    return;
                }

                // Get maximum reimbursement limit
                Console.Write("Enter maximum reimbursement limit: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal maxLimit) || maxLimit <= 0)
                {
                    Console.WriteLine("Invalid limit. Must be a positive number.");
                    return;
                }

                // Get coverage percentage
                Console.Write("Enter coverage percentage (0-100): ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal coveragePercent))
                {
                    Console.WriteLine("Invalid percentage.");
                    return;
                }

                // Calculate reimbursement
                decimal reimbursement = CalculateReimbursement(claimAmount, maxLimit, coveragePercent);

                // Display result
                Console.WriteLine($"\nClaim Amount: {claimAmount:C}");
                Console.WriteLine($"Coverage: {coveragePercent}%");
                Console.WriteLine($"Max Limit: {maxLimit:C}");
                Console.WriteLine($"Reimbursable Amount: {reimbursement:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

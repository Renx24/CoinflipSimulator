using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinflip
{
    internal class ProbabilityPercentage
    {
        private const double ProbabilityPerFlip = 0.5; // Probability of heads or tails

        // Method to calculate factorial of a number
        private static double Factorial(int n)
        {
            if (n == 0 || n == 1) return 1;
            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // Method to calculate combinations
        private static double Combinations(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        // Method to calculate probability percentage of exactly k heads in n flips
        public static double CalculateProbability(int n, int k)
        {
            double combinations = Combinations(n, k);
            double probability = combinations * Math.Pow(ProbabilityPerFlip, k) * Math.Pow(1 - ProbabilityPerFlip, n - k);
            return probability * 100; // Return as percentage
        }
    }
}

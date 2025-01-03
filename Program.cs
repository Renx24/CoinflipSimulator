﻿
namespace Coinflip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<string> flipArray = new List<string>();
            string goAgain = "y";

            while (goAgain == "y")
            {
                Console.WriteLine("Coinflip simulator.");
                Console.WriteLine("Please enter amount of coinflips. Amount <= 100 also shows probability of the scenario happening.\n");
                string amountStr = Console.ReadLine();
                int amount;

                // While "input is incorrect" logic
                while (!int.TryParse(amountStr, out amount) || int.Parse(amountStr) <= 0) {
                    Console.WriteLine("\nInvalid input, please enter a positive number.");
                    amountStr = Console.ReadLine();
                }
                

                // Hard-coded for only one coinflip
                if (amount == 1)
                {
                    Console.WriteLine($"\n{(rand.Next(0, 101) > 50 ? "Heads" : "Tails")}\n");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Here's the result of flipping the coin {amount} times:");
                    Console.WriteLine();
                    for (int i = 0; i < amount; i++)
                    {
                        flipArray.Add((rand.Next(0, 101) > 50 ? "Heads" : "Tails"));
                        if (i == amount - 1)
                        {
                            // Count amount of heads and tails in flipArray list
                            int headsAmount = flipArray.Count(x => x == "Heads");
                            int tailsAmount = flipArray.Count(x => x == "Tails");
                            Console.WriteLine($"{headsAmount} heads.");
                            Console.WriteLine($"{tailsAmount} tails.\n");

                            // Calculate and display probability of this exact scenario happening if amount <= 100
                            double probability = ProbabilityPercentage.CalculateProbability(amount, headsAmount);
                            if (amount <= 100)
                            {
                                Console.WriteLine($"The probability of getting exactly {headsAmount} heads and {tailsAmount} tails is {probability:F2}%.\n");
                            }

                            // Boolean to view list according to prompt by user
                            string seeList = "n";
                            Console.WriteLine("Do you want to see the list to verify? (y/n)\n");
                            seeList = Console.ReadLine();

                            if (seeList == "y")
                            {
                                for (int j = 0; j < amount; j++)
                                {
                                    Console.WriteLine(flipArray[j]);
                                }
                            }
                        }

                    }
                }
                // Reset flipArray and ask user if they would like to flip again
                flipArray.Clear();
                Console.WriteLine("Want to try again? (y/n)\n");
                goAgain = Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}

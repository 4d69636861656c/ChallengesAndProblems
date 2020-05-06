using System;

// Displays statistics on dice rolls. 

namespace RollOfDiceSimulator
{
    class EntryPoint
    {
        static void Main()
        {
            Die die1 = new Die();
            Die die2 = new Die();

            int[] stats = new int[13];
            int[,] rolls = new int[7, 7];

            string lineSeparator = new string('-', 55);

            Console.Write("How many times would you like to roll the dice? Input: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int die1Value = die1.DieRoll();
                int die2Value = die2.DieRoll();

                rolls[die1Value, die2Value]++;

                int sum = die1Value + die2Value;
                stats[sum]++;
            }

            // Display sums. 
            for (int i = 2; i <= 12; i++)
            {
                Console.WriteLine($"Sum of {i} occurred {stats[i]} times.");
            }

            Console.WriteLine();
            Console.WriteLine("\t1\t2\t3\t4\t5\t6");
            Console.WriteLine(lineSeparator);

            for (int r = 1; r <= 6; r++)
            {
                Console.Write($"{r}");
                for (int c = 1; c <= 6; c++)
                {
                    Console.Write($"\t{rolls[r, c]}");
                }
                Console.WriteLine($"{Environment.NewLine}");
            }
        }
    }
}
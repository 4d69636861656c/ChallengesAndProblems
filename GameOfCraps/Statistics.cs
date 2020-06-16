using System;
using System.Linq;

namespace GameOfCraps
{
    internal class Statistics
    {
        internal static int[] Wins = new int[22];
        internal static int[] Loses = new int[22];

        internal double AverageLength()
        {
            double average;
            int sumOfRounds = 0;

            for (int i = 1; i <= 21; i++)
            {
                sumOfRounds += (Wins[i] * 1) + (Loses[i] * i);
            }

            average = (sumOfRounds * 1.0) / (Wins.Sum() + Loses.Sum());

            return average;
        }

        internal void SetStats(int round, CrapsGame.GameStatus result)
        {
            if (result == CrapsGame.GameStatus.Win)
            {
                if (round <= 20)
                {
                    Wins[round]++;
                }
                else
                {
                    Wins[21]++;
                }
            }
            else if (result == CrapsGame.GameStatus.Lose)
            {
                if (round <= 20)
                {
                    Loses[round]++;
                }
                else
                {
                    Loses[21]++;
                }
            }
        }

        internal void DisplayStatistics()
        {
            double probability;
            double average;

            for (int i = 1; i <= 21; i++)
            {
                if (i == 21)
                {
                    Console.WriteLine($"Round 21 or more wins: {Wins[i]}");
                }
                else
                {
                    Console.WriteLine($"Round {i} wins: {Wins[i]}");
                }
            }

            for (int i = 1; i <= 21; i++)
            {
                if (i == 21)
                {
                    Console.WriteLine($"Round 21 or more loses: {Loses[i]}");
                }
                else
                {
                    Console.WriteLine($"Round {i} loses: {Loses[i]}");
                }
            }

            probability = ProbabilityOfWinning();
            Console.WriteLine($"Chances of winning the game of craps are {probability:P}.");
            Console.WriteLine($"Average length of a game of craps is {AverageLength():N2} rounds.");
        }

        internal double ProbabilityOfWinning()
        {
            return (Wins.Sum() * 1.0) / (Wins.Sum() + Loses.Sum());
        }
    }
}
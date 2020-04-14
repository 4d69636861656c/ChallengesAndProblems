using System;

namespace SieveOfEratosthenes
{
    class EntryPoint
    {
        private static bool[] allNumbers;

        static void Main()
        {
            Console.Write("Please enter the number n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int arraySize = n++;
            InitializeBoolenArray(arraySize);
            Console.WriteLine("Prime numbers list: ");
            Sieve(arraySize);
        }

        private static void Sieve(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (allNumbers[i])
                {
                    for (int c = i; i * c < n; c++)
                    {
                        allNumbers[i * c] = false;
                    }
                }
            }

            int counter = 0;
            for (int i = 2; i < n; i++)
            {
                if (allNumbers[i])
                {
                    Console.Write($"{i}\t");
                    counter++;
                }

                if (counter == 10)
                {
                    Console.Write($"{System.Environment.NewLine}");
                    counter = 0;
                }
            }
        }

        private static void InitializeBoolenArray(int n)
        {
            allNumbers = new bool[n];

            for (int i = 0; i < n; i++)
            {
                allNumbers[i] = true;
            }
        }
    }
}
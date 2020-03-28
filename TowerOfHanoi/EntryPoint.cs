using System;

namespace TowerOfHanoi
{
    class EntryPoint
    {
        private static int counter = 0;

        static void Main()
        {
            Console.Write("Please enter the number of discs: ");
            string userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int discs))
            {
                Tower(discs, 1, 3, 2);
            }
            else
            {
                Console.WriteLine("The input needs to be a number. Please try again.");
            }
        }

        private static void Tower(int n, int sourcePeg, int destinationPeg, int sparePeg)
        {
            if (n == 1)
            {
                Console.WriteLine($"{counter}. {sourcePeg} -> {destinationPeg}");
                counter++;
            }
            else
            {
                Tower(n - 1, sourcePeg, sparePeg, destinationPeg);
                Console.WriteLine($"{counter}. {sourcePeg} -> {destinationPeg}");
                counter++;
                Tower(n - 1, sparePeg, destinationPeg, sourcePeg);
            }
        }
    }
}
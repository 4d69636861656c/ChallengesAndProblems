using System;
using System.Threading;
using static FallingBricks.ArrayUtilities;

namespace FallingBricks
{
    class EntryPoint
    {
        static void Main()
        {
            int[,] array = InitializeArray(10, 8);

            bool isArrayEmpty = false;

            Console.WriteLine("Initial array is: ");
            DisplayArray(array);

            while (!isArrayEmpty)
            {
                // Gives user some time to look over the new array. 
                Thread.Sleep(1000);

                // Important operations to the array elements. 
                EliminateRandomElement(array);
                ApplyGravityToArray(array);
                Console.WriteLine($"{System.Environment.NewLine}New array is: ");
                DisplayArray(array);
                Console.WriteLine(new string('-', (array.GetLength(1) * 8)));

                // Ending condition. 
                isArrayEmpty = IsArrayEmpty(array);
                if (isArrayEmpty)
                {
                    Console.WriteLine("There are no more elements to delete.");
                    Console.WriteLine("Exiting program ... ");
                }
            }
        }
    }
}
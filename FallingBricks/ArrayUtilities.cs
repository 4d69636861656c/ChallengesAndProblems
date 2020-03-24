using System;
using static ConsoleManipulation.ConsoleUtilities;

namespace FallingBricks
{
    public static class ArrayUtilities
    {
        public static int[,] ApplyGravityToArray(int[,] array)
        {
            bool isBaseZero = true;

            while (isBaseZero)
            {
                MoveElementsDownwards(array);
                isBaseZero = IsBaseStable(array);
            }

            return array;
        }

        public static bool IsBaseStable(int[,] array)
        {
            bool isBaseZero = default;

            for (int row = array.GetLength(0) - 1; row > 0; row--)
            {
                isBaseZero = false;

                for (int col = 0; col < array.GetLength(1); col++)
                {
                    if (array[row, col] == 0 && array[row - 1, col] != 0)
                    {
                        isBaseZero = true;
                        break;
                    }
                }

                if (isBaseZero == true)
                {
                    break;
                }
            }

            return isBaseZero;
        }

        public static void MoveElementsDownwards(int[,] array)
        {
            for (int row = array.GetLength(0) - 1; row > 0; row--)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    if (array[row, col] == 0 && array[row - 1, col] != 0)
                    {
                        ColorfulWriteLine($"Element {array[row - 1, col]} at row {row - 1}, column {col} will be moved one row down.", ConsoleColor.Green);
                        array[row, col] = array[row - 1, col];
                        array[row - 1, col] = 0;
                    }
                }
            }
        }

        public static bool IsArrayEmpty(int[,] array)
        {
            bool isArrayEmpty = true;

            for (int row = 0; row < array.GetLength(0); row++)
            {
                if (isArrayEmpty == true)
                {
                    for (int col = 0; col < array.GetLength(1); col++)
                    {
                        isArrayEmpty = true;

                        if (array[row, col] != 0)
                        {
                            isArrayEmpty = false;
                            break;
                        }
                    }
                }
            }

            return isArrayEmpty;
        }

        public static void DisplayArray(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write($"{array[row, col]}\t");
                }
                Console.WriteLine();
            }
        }

        public static int[,] EliminateRandomElement(int[,] array)
        {
            Random rng = new Random();

            int row = 0;
            int col = 0;

            while (array[row, col] == 0)
            {
                row = rng.Next(0, array.GetLength(0));
                col = rng.Next(0, array.GetLength(1));
            }

            ColorfulWriteLine($"Element {array[row, col]} at row {row}, column {col} was deleted!", ConsoleColor.Red);

            array[row, col] = 0;

            return array;
        }

        public static int[,] InitializeArray(int n, int m)
        {
            int[,] array = new int[n, m];

            Random rng = new Random();

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    array[row, col] = rng.Next(1, 10);
                }
            }

            return array;
        }
    }
}
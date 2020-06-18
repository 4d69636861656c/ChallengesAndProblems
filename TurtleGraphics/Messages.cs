using System;

namespace TurtleGraphics
{
    internal static class Messages
    {
        internal static string ErrorMessage { get; set; }

        internal static void Instructions()
        {
            Console.WriteLine("Type your commands to draw on the game board.");
            Console.WriteLine("1. Pen up\t2. Pen down");
            Console.WriteLine("3. North\t4. East\t\t5. South\t6.West");
            Console.WriteLine("7. Quit");
        }

        internal static void InvalidInput()
        {
            ErrorMessage = "\nInvalid input. Input must be an integer between 1 and 7.\n";
        }

        internal static void InvalidMove(Directions.TurtleDirections direction, int spaces)
        {
            ErrorMessage = $"\nInvalid move. You can only move {spaces} spaces to the {direction}.";
        }
    }
}
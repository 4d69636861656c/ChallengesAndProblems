using System;

namespace FallingBricks
{
    public static class ColorfulUtilities
    {
        public static void ColorfulWriteLine(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
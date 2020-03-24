using System;

namespace ConsoleManipulation
{
    public static class ConsoleUtilities
    {
        public static void ColorfulWriteLine(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
using System;

namespace TurtleGraphics
{
    internal class EntryPoint
    {
        static void Main()
        {
            Game game = new Game();
            game.GameLoop();

            Console.WriteLine($"{Environment.NewLine}Thanks for playing! Goodbye!{Environment.NewLine}");
        }
    }
}
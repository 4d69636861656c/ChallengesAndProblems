using System;

namespace GameOfCraps
{
    internal class RollDice
    {
        private readonly Random _rng = new Random();

        internal int Die1 { get; set; }
        internal int Die2 { get; set; }

        internal int DiceRoll()
        {
            Die1 = _rng.Next(1, 7);
            Die2 = _rng.Next(1, 7);

            return Die1 + Die2;
        }
    }
}
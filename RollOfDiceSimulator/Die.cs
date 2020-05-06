using System;

namespace RollOfDiceSimulator
{
    public class Die
    {
        private static readonly Random rng = new Random();

        public int DieRoll()
        {
            return rng.Next(1, 7);
        }
    }
}
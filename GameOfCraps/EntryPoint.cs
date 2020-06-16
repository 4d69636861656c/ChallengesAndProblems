using System;

namespace GameOfCraps
{
    internal class EntryPoint
    {
        static void Main()
        {
            CrapsGame craps = new CrapsGame();
            craps.Play();
        }
    }
}
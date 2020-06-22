using System;

namespace TortoiseVersusHareRaceSimulation
{
    public class Track
    {
        public const int TrackLength = 25;
        public const int NumOfRunners = 3;

        public string[,] Tracks { get; set; }

        public Track()
        {
            Tracks = new string[TrackLength + 1, NumOfRunners];
        }

        public void DisplayRaceTrack()
        {
            System.Console.WriteLine();
            for (int i = 0; i <= TrackLength; i++)
            {
                Console.Write(i + "\t| ");
                for (int c = 0; c < NumOfRunners; c++)
                {
                    if (Tracks[i, c] == null)
                    {
                        Console.Write("  | ");
                    }
                    else
                    {
                        Console.Write(Tracks[i, c] + " | ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void RunnerPosition(Runner runner)
        {
            Tracks[runner.OrigPosition, runner.Lane] = null;
            Tracks[runner.CurrentPosition, runner.Lane] = runner.RunnerSymbol;
        }
    }
}
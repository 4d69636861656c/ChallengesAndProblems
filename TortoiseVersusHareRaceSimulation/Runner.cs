using System;
using System.Collections.Generic;

namespace TortoiseVersusHareRaceSimulation
{
    public abstract class Runner
    {
        private static readonly Random _rng = new Random();
        private int origPosition;
        private string runnerSymbol;
        private int currentPosition;
        private int lane;
        private string name;
        private string moveDescription;

        public static List<Runner> AllRunners = new List<Runner>();
        public int OrigPosition { get => origPosition; set => origPosition = value; }
        public string RunnerSymbol { get => runnerSymbol; set => runnerSymbol = value; }
        public int CurrentPosition { get => currentPosition; set => currentPosition = value; }
        public int Lane { get => lane; set => lane = value; }
        public string Name { get => name; set => name = value; }
        public string MoveDescription { get => moveDescription; set => moveDescription = value; }

        public int GetMoveType()
        {
            return _rng.Next(1, 101);
        }

        public void MakeMove(int spaces)
        {
            OrigPosition = CurrentPosition;

            if (CurrentPosition + spaces < 0)
            {
                CurrentPosition = 0;
            }
            else if (CurrentPosition + spaces > Track.TrackLength)
            {
                CurrentPosition = Track.TrackLength;
            }
            else
            {
                CurrentPosition += spaces;
            }
        }

        public bool IsWinner(Runner runner)
        {
            if (runner.CurrentPosition == Track.TrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract void CalculateMove();
    }
}
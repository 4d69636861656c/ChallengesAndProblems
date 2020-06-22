using System;
using System.Linq;

namespace TortoiseVersusHareRaceSimulation
{
    public class Race
    {
        private Track _track;
        private bool _raceOver;

        public Race()
        {
            _track = new Track();
            new Tortoise(0, 0, "Tanky");
            new Hare(0, 1, "Fluffy");
            new Duck(0, 2, "Ducky");
            _raceOver = false;
        }

        public void Racing()
        {
            SetUpRace();

            do
            {
                Console.ReadLine();
                Console.Clear();
                _track.DisplayRaceTrack();

                foreach (Runner runner in Runner.AllRunners)
                {
                    Console.WriteLine(runner.MoveDescription);
                    runner.CalculateMove();
                    _track.RunnerPosition(runner);

                    if (runner.IsWinner(runner))
                    {
                        _raceOver = true;
                    }
                }
            } while (!_raceOver);

            Console.Clear();
            _track.DisplayRaceTrack();
            GetPlace();
        }

        private void SetUpRace()
        {
            foreach (Runner runner in Runner.AllRunners)
            {
                _track.RunnerPosition(runner);
            }
            System.Console.WriteLine("Welcome to the ultimate race! Press any key to continue.");
        }

        public void GetPlace()
        {
            foreach (Runner runner in Runner.AllRunners.Where(x => x.CurrentPosition == Track.TrackLength))
            {
                Console.WriteLine($"The winner(s): {runner.Name}.");
            }
        }
    }
}
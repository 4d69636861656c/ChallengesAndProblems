using static TortoiseVersusHareRaceSimulation.MoveType;

namespace TortoiseVersusHareRaceSimulation
{
    public class Tortoise : Runner
    {
        public Tortoise(int currentPosition, int lane, string name)
        {
            base.CurrentPosition = currentPosition;
            base.Lane = lane;
            base.Name = name;
            base.RunnerSymbol = "T";
            base.MoveDescription = $"{base.Name} is ready! Set! Go!";
            AllRunners.Add(this);
        }

        public override void CalculateMove()
        {
            int move = GetMoveType();

            if (move >= 1 && move <= 50)
            {
                MakeMove(FastPlod);
                MoveDescription = $"{Name} moved Fast Plod (+3).";
            }
            else if (move >= 51 && move <= 70)
            {
                MakeMove(Slip);
                MoveDescription = $"{Name} Slipped (-6).";
            }
            else
            {
                MakeMove(SlowPlod);
                MoveDescription = $"{Name} moved Slow Plod (+1).";
            }
        }
    }
}
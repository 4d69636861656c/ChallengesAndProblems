using static TortoiseVersusHareRaceSimulation.MoveType;

namespace TortoiseVersusHareRaceSimulation
{
    public class Hare : Runner
    {
        public Hare(int currentPosition, int lane, string name)
        {
            base.CurrentPosition = currentPosition;
            base.Lane = lane;
            base.Name = name;
            base.RunnerSymbol = "H";
            base.MoveDescription = $"{base.Name} is ready! Set! Go!";
            AllRunners.Add(this);
        }

        public override void CalculateMove()
        {
            int move = GetMoveType();

            if (move >= 1 && move <= 20)
            {
                MakeMove(Sleep);
                MoveDescription = $"{Name} is Sleeping (0).";
            }
            else if (move >= 21 && move <= 40)
            {
                MakeMove(BigHop);
                MoveDescription = $"{Name} made a Big Hop (+9).";
            }
            else if (move >= 41 && move <= 50)
            {
                MakeMove(BigSlip);
                MoveDescription = $"{Name} made a Big Slip (-12).";
            }
            else if (move >= 51 && move <= 80)
            {
                MakeMove(BigSlip);
                MoveDescription = $"{Name} made a Small Hop (+1).";
            }
            else
            {
                MakeMove(SmallSlip);
                MoveDescription = $"{Name} made a Small Slip (-2).";
            }
        }
    }
}
namespace TurtleGraphics
{
    internal class Turtle
    {
        internal char TurtleSymbol { get; set; }
        internal int PositionX { get; set; }
        internal int PositionY { get; set; }

        internal Turtle()
        {
            TurtleSymbol = 'X';
            PositionX = 0;
            PositionY = 0;
        }

        internal void Walk(Directions.TurtleDirections direction, int spaces, Pen.PenActions pen)
        {
            if (ValidateMove(direction, spaces))
            {
                bool toDraw = (pen == Pen.PenActions.Down);

                switch (direction)
                {
                    case Directions.TurtleDirections.North:
                        if (toDraw)
                        {
                            GameBoard.UpdateGameBoardX(PositionX, spaces, -1, PositionY);
                        }
                        PositionX -= spaces;
                        break;
                    case Directions.TurtleDirections.South:
                        if (toDraw)
                        {
                            GameBoard.UpdateGameBoardX(PositionX, spaces, 1, PositionY);
                        }
                        PositionX += spaces;
                        break;
                    case Directions.TurtleDirections.East:
                        if (toDraw)
                        {
                            GameBoard.UpdateGameBoardY(PositionY, spaces, 1, PositionX);
                        }
                        PositionY += spaces;
                        break;
                    case Directions.TurtleDirections.West:
                        if (toDraw)
                        {
                            GameBoard.UpdateGameBoardY(PositionY, spaces, -1, PositionX);
                        }
                        PositionY -= spaces;
                        break;
                }
            }
        }

        private bool ValidateMove(Directions.TurtleDirections direction, int spaces)
        {
            if (direction == Directions.TurtleDirections.North && (PositionX - spaces) < 0)
            {
                Messages.InvalidMove(direction, PositionX);
                return false;
            }

            if (direction == Directions.TurtleDirections.East && (PositionY + spaces) > GameBoard.GAME_BOARD_SIZE - 1)
            {
                Messages.InvalidMove(direction, GameBoard.GAME_BOARD_SIZE - PositionY - 1);
                return false;
            }

            if (direction == Directions.TurtleDirections.South && (PositionX + spaces) > GameBoard.GAME_BOARD_SIZE - 1)
            {
                Messages.InvalidMove(direction, GameBoard.GAME_BOARD_SIZE - PositionX - 1);
                return false;
            }

            if (direction == Directions.TurtleDirections.West && (PositionY - spaces) < 0)
            {
                Messages.InvalidMove(direction, PositionY);
                return false;
            }

            return true;
        }
    }
}
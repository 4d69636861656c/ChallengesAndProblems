using System;

namespace TurtleGraphics
{
    internal class Game
    {
        private Pen.PenActions _pen;
        private Directions.TurtleDirections _direction;
        private Turtle _turtle;
        private GameBoard _gameBoard;
        private bool _quit; // Quit the game. 
        private int _option;

        internal Game()
        {
            _turtle = new Turtle();
            _gameBoard = new GameBoard();
            _quit = false;
            _pen = Pen.PenActions.Up;
            _direction = Directions.TurtleDirections.South;
        }

        internal void GameLoop()
        {
            _gameBoard.InitiateGameBoard();

            do
            {
                Console.Clear();

                Console.WriteLine(Messages.ErrorMessage);
                Messages.ErrorMessage = string.Empty;

                _gameBoard.DrawGameBoard(_turtle.PositionX, _turtle.PositionY, _turtle.TurtleSymbol);
                Messages.Instructions();
                Console.WriteLine("Pen is " + (_pen == Pen.PenActions.Down ? "drawing" : "not drawing") + ".");
                Console.WriteLine($"Turtle is moving {_direction}.");

                Console.Write("Select your option: ");
                if (int.TryParse(Console.ReadLine(), out _option))
                {
                    if (_option > 0 && _option < 3)
                    {
                        _pen = (Pen.PenActions)_option;
                    }
                    else if (_option > 2 && _option < 7)
                    {
                        _direction = (Directions.TurtleDirections)_option;
                        Console.WriteLine($"Turtle is moving {_direction}.");
                        Console.Write("Enter number of spaces to move: ");
                        int spaces;
                        if (int.TryParse(Console.ReadLine(), out spaces))
                        {
                            _turtle.Walk(_direction, spaces, _pen);
                        }
                        else
                        {
                            Messages.InvalidInput();
                        }
                    }
                    else if (_option == 7)
                    {
                        _quit = true;
                    }
                    else
                    {
                        Messages.InvalidInput();
                    }
                }
                else
                {
                    Messages.InvalidInput();
                }
            } while (!_quit);
        }
    }
}
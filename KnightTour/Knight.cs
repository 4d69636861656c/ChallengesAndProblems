using System;
using System.Linq;

namespace KnightTour
{
    internal class Knight
    {
        private static int _bestScore = 0;
        private static int _tourCount = 0;

        private Random _rng = new Random();
        private readonly Board _board;

        private int _currentPositionH;
        private int _currentPositionV;
        private bool _isFullTour = false;
        private bool _isEndTour = false;
        private int _moveCounter;

        public Knight()
        {
            _board = new Board();
        }

        internal void Move()
        {
            while (!_isFullTour)
            {
                _currentPositionH = _rng.Next(Board.SIZE);
                _currentPositionV = _rng.Next(Board.SIZE);
                _moveCounter = 1;
                _board.PopulateArray(_currentPositionH, _currentPositionV);
                _isEndTour = false;

                do
                {
                    if (!IsMoving())
                    {
                        GetTourResults();
                    }
                } while (!_isEndTour);
            }

        }

        private void GetTourResults()
        {
            _isEndTour = true;

            if (_moveCounter == Board.SIZE * Board.SIZE)
            {
                _isFullTour = true;
                _board.DisplayBoard();
                Console.WriteLine($"Success! The tour number {_tourCount} was a complete tour!{Environment.NewLine}");
                return;
            }

            if (_moveCounter == _bestScore)
            {
                _board.DisplayBoard();
                Console.WriteLine($"No success. The best score is still {_bestScore} moves reached again on this tour number {_tourCount}.{Environment.NewLine}");
            }
            else if (_moveCounter > _bestScore)
            {
                _bestScore = _moveCounter;
                _board.DisplayBoard();
                Console.WriteLine($"No success, but getting closer! {_bestScore} moves reached on tour number {_tourCount}.{Environment.NewLine}");
            }
        }

        internal bool IsMoving()
        {
            int[] movesTaken = { 0, 0, 0, 0, 0, 0, 0, 0 };
            bool allMovesUsed = false;

            while (!allMovesUsed)
            {
                int i = _rng.Next(8);
                if (movesTaken[i] == 0)
                {
                    int hMove = _currentPositionH + _board.Horizontal[i];
                    int vMove = _currentPositionV + _board.Vertical[i];

                    if (hMove >= 0 && hMove < Board.SIZE && vMove >= 0 && vMove < Board.SIZE && _board.ChessBoard[hMove, vMove] == Board.BOARD_SYMBOL)
                    {
                        _currentPositionH = hMove;
                        _currentPositionV = vMove;
                        _board.ChessBoard[_currentPositionH, _currentPositionV] = Board.MOVE_SYMBOL;
                        _moveCounter++;
                        return true;
                    }

                    movesTaken[i] = 1;
                }

                if (!movesTaken.Contains(0))
                {
                    allMovesUsed = true;
                }
            }

            _tourCount++;
            return false;
        }
    }
}
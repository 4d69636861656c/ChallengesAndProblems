using System;

namespace EightQueens
{
    internal class Run
    {
        private readonly Board _board;
        private static Random _rng;

        private int _runCounter;
        private int _queensCounter;
        private bool[] _usedRows;

        public Run()
        {
            _board = new Board();
            _rng = new Random();

            _runCounter = 0;
            _queensCounter = 0;
            _usedRows = new bool[8];
        }

        private bool CountQueens(int attackingQueenCounter)
        {
            if (attackingQueenCounter > 1)
            {
                _queensCounter = 0;
                Array.Clear(_usedRows, 0, 8);
                _board.Initialize();
                return false;
            }

            return true;
        }

        internal bool IsValidRow(int row)
        {
            if (!_usedRows[row])
            {
                _usedRows[row] = true;
                return true;
            }

            return false;
        }

        internal bool IsWinner()
        {
            _board.DisplayBoard();
            Console.WriteLine();

            int attackingQueenCounter = 0;
            for (int c = 0; c < Board.SIZE - 1; c++)
            {
                for (int r = 0; r <= (Board.SIZE - 1) - c; r++)
                {
                    if (_board.board[r, c + r] != Board.BOARD_CHAR)
                    {
                        attackingQueenCounter++;
                        if (!CountQueens(attackingQueenCounter))
                        {
                            return false;
                        }
                    }
                }
                attackingQueenCounter = 0;
            }

            attackingQueenCounter = 0;
            for (int r = 0; r < Board.SIZE - 1; r++)
            {
                for (int c = Board.SIZE - 1; c >= r; c--)
                {
                    if (_board.board[(Board.SIZE - 1) - c + r, c] != Board.BOARD_CHAR)
                    {
                        attackingQueenCounter++;
                        if (!CountQueens(attackingQueenCounter))
                        {
                            return false;
                        }
                    }
                }
                attackingQueenCounter = 0;
            }

            attackingQueenCounter = 0;
            for (int c = Board.SIZE - 1; c > 0; c--)
            {
                for (int r = Board.SIZE - 1; r >= Board.SIZE - 1 - c; r--)
                {
                    if (_board.board[r, c + r - (Board.SIZE - 1)] != Board.BOARD_CHAR)
                    {
                        attackingQueenCounter++;
                        if (!CountQueens(attackingQueenCounter))
                        {
                            return false;
                        }
                    }
                }
                attackingQueenCounter = 0;
            }

            attackingQueenCounter = 0;
            for (int r = Board.SIZE - 1; r > 0; r--)
            {
                for (int c = 0; c <= r; c++)
                {
                    if (_board.board[r - c, c] != Board.BOARD_CHAR)
                    {
                        attackingQueenCounter++;
                        if (!CountQueens(attackingQueenCounter))
                        {
                            return false;
                        }
                    }
                }
                attackingQueenCounter = 0;
            }

            return true;
        }

        internal void PlaceQueens()
        {
            _board.Initialize();

            do
            {
                SetPosition();
                Console.WriteLine(_runCounter);
            } while (!IsWinner());

            Console.WriteLine($"It took {_runCounter} attempts to make the queens set up correctly.");
        }

        internal void SetPosition()
        {
            int col = 0;
            int row = 0;

            while (_queensCounter < 8)
            {
                row = _rng.Next(0, Board.SIZE);
                if (IsValidRow(row))
                {
                    _board.board[row, col] = Board.QUEEN_CHAR;
                    col++;
                    _queensCounter++;
                }
            }

            _runCounter++;
        }
    }
}
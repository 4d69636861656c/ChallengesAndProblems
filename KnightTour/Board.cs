using System;

namespace KnightTour
{
    internal class Board
    {
        internal const int SIZE = 8;
        internal const char BOARD_SYMBOL = '.';
        internal const char MOVE_SYMBOL = 'X';

        private int[] _horizontal;
        private int[] _vertical;

        internal char[,] ChessBoard { get; set; }

        internal int[] Horizontal
        {
            get
            {
                return _horizontal;
            }
        }

        internal int[] Vertical
        {
            get
            {
                return _vertical;
            }
        }

        public Board()
        {
            _horizontal = new[] { 2, 1, -1, -2, -2, -1, 1, 2 };
            _vertical = new[] { -1, -2, -2, -1, 1, 2, 2, 1 };
            ChessBoard = new char[SIZE, SIZE];
        }

        internal void PopulateArray(int startingPositionH = 3, int startingPositionV = 4)
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int c = 0; c < SIZE; c++)
                {
                    ChessBoard[i, c] = BOARD_SYMBOL;
                }
            }

            ChessBoard[startingPositionH, startingPositionV] = MOVE_SYMBOL;
        }

        internal void DisplayBoard()
        {
            // Display characters for each column on the board. 
            Console.Write("  ");
            for (int i = 65; i < (65 + SIZE); i++)
            {
                Console.Write(value: Convert.ToChar(i));
            }
            Console.WriteLine();

            // Display the chess board. 
            for (int r = 0; r < SIZE; r++)
            {
                Console.Write($"{r + 1} ");
                for (int c = 0; c < SIZE; c++)
                {
                    Console.Write(ChessBoard[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
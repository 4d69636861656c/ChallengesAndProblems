using System;

namespace EightQueens
{
    internal class Board
    {
        internal const char BOARD_CHAR = '.';
        internal const char QUEEN_CHAR = 'Q';
        internal const int SIZE = 8;

        internal char[,] board;

        public Board()
        {
            board = new char[8, 8];
        }

        internal void Initialize()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int c = 0; c < SIZE; c++)
                {
                    board[i, c] = BOARD_CHAR;
                }
            }
        }

        internal void DisplayBoard()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int c = 0; c < SIZE; c++)
                {
                    Console.Write($"{board[i, c]}  ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
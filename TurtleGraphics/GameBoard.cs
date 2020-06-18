using System;

namespace TurtleGraphics
{
    internal class GameBoard
    {
        internal const int GAME_BOARD_SIZE = 20; // Default size. 
        internal const char USED_SPACE = 'O';
        internal const char GAME_BOARD_SYMBOL = '.';

        internal static char[,] GameBoardArray { get; set; }

        internal GameBoard()
        {
            GameBoardArray = new char[GAME_BOARD_SIZE, GAME_BOARD_SIZE];
        }

        internal void InitiateGameBoard()
        {
            for (int i = 0; i < GAME_BOARD_SIZE; i++)
            {
                for (int c = 0; c < GAME_BOARD_SIZE; c++)
                {
                    GameBoardArray[i, c] = GAME_BOARD_SYMBOL;
                }
            }
        }

        internal void DrawGameBoard(int posX, int posY, char turtle)
        {
            for (int i = 0; i < GAME_BOARD_SIZE; i++)
            {
                for (int c = 0; c < GAME_BOARD_SIZE; c++)
                {
                    if (i == posX && c == posY)
                    {
                        Console.Write(turtle);
                    }
                    else
                    {
                        Console.Write(GameBoardArray[i, c]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal static void UpdateGameBoardX(int start, int spacesToMove, int upOrDown, int constantY)
        {
            for (int i = 0; i < spacesToMove; i++)
            {
                GameBoardArray[start + (i * upOrDown), constantY] = USED_SPACE;
            }
        }

        internal static void UpdateGameBoardY(int start, int spacesToMove, int leftOrRight, int constantX)
        {
            for (int i = 0; i < spacesToMove; i++)
            {
                GameBoardArray[constantX, start + (i * leftOrRight)] = USED_SPACE;
            }
        }
    }
}
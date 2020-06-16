using System;

namespace GameOfCraps
{
    internal class CrapsGame
    {
        internal const int NUM_GAMES = 10000;

        private Statistics _statistics;

        private enum DiceSum
        {
            SnakeEyes = 2,
            Trey = 3,
            Seven = 7,
            YoLevel = 11,
            BoxCars = 12
        };

        internal enum GameStatus
        {
            Win,
            Lose,
            Continue
        };

        private readonly RollDice _roll;
        private GameStatus _gameStatus;
        private DiceSum _diceSum;
        private int _numRolls;
        private int _sum;
        private int _points;

        internal CrapsGame()
        {
            _roll = new RollDice();
            _statistics = new Statistics();
        }

        private void EvaluateRoll()
        {
            switch (_sum)
            {
                case 7:
                    _diceSum = DiceSum.Seven;
                    _gameStatus = GameStatus.Win;
                    _points = 0;
                    _statistics.SetStats(_numRolls, _gameStatus);
                    break;
                case 11:
                    _diceSum = DiceSum.YoLevel;
                    _gameStatus = GameStatus.Win;
                    _points = 0;
                    _statistics.SetStats(_numRolls, _gameStatus);
                    break;
                case 2:
                    _diceSum = DiceSum.SnakeEyes;
                    _gameStatus = GameStatus.Lose;
                    _points = 0;
                    _statistics.SetStats(_numRolls, _gameStatus);
                    break;
                case 3:
                    _diceSum = DiceSum.Trey;
                    _gameStatus = GameStatus.Lose;
                    _points = 0;
                    _statistics.SetStats(_numRolls, _gameStatus);
                    break;
                case 12:
                    _diceSum = DiceSum.BoxCars;
                    _gameStatus = GameStatus.Lose;
                    _points = 0;
                    _statistics.SetStats(_numRolls, _gameStatus);
                    break;
                default:
                    _gameStatus = GameStatus.Continue;
                    _points = _sum;
                    break;
            }
        }

        private void DisplayMessage()
        {
            switch (_gameStatus)
            {
                case GameStatus.Win:
                    Console.WriteLine(_numRolls == 1 ? $"Congratulations, you rolled {_diceSum}. You win!" : $"Congratulations, you rolled {_sum}. You win!");
                    break;
                case GameStatus.Lose:
                    Console.WriteLine(_numRolls == 1 ? $"Sorry, you rolled {_diceSum}. You lose!" : $"Sorry, you rolled {_sum}. You lose!");
                    break;
                default:
                    Console.WriteLine($"You rolled {_sum}. Your point is {_points}. Keep rolling!");
                    break;
            }
        }

        internal void Play()
        {
            for (int i = 0; i < NUM_GAMES; i++)
            {
                Console.WriteLine($"{new string('-', 15)}> Game Number {i + 1} <{new string('-', 15)}");
                _gameStatus = GameStatus.Continue;
                _numRolls = 0;

                _sum = _roll.DiceRoll();
                _numRolls++;
                EvaluateRoll();
                DisplayMessage();

                while (_gameStatus == GameStatus.Continue)
                {
                    KeepPlaying();
                    DisplayMessage();
                }
                Console.WriteLine($"{new string('*', 48)}{Environment.NewLine}");
            }

            _statistics.DisplayStatistics();
        }

        private void KeepPlaying()
        {
            _sum = _roll.DiceRoll();
            _numRolls++;

            if (_sum == _points)
            {
                _gameStatus = GameStatus.Win;
                _statistics.SetStats(_numRolls, _gameStatus);
            }
            else if (_sum == 7)
            {
                _gameStatus = GameStatus.Lose;
                _statistics.SetStats(_numRolls, _gameStatus);
            }
            else
            {
                _gameStatus = GameStatus.Continue;
            }
        }
    }
}
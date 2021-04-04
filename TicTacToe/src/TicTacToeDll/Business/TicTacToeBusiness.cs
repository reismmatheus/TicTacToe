using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeDll.Model;

namespace TicTacToeDll.Business
{
    public static class TicTacToeBusiness
    {
        private static readonly int boardSize = 3;
        private static Random random = new Random();
        public static void ShowBoard(this TicTacToeBoard board)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write($"{ShowMove(board.Board[i, j])} ");
                }
                Console.WriteLine("");
            }
        }

        public static void PlayPlayer(this TicTacToeBoard board, int column, int line)
        {
            board.Board[column - 1, line - 1] = 1;
            board.Plays++;
            board.ShowBoard();
            board.UpdateStatusGame();
        }

        public static void PlayComputer(this TicTacToeBoard board)
        {
            var column = 0;
            var line = 0;

            if(board.Difficulty == Difficulty.Easy)
            {
                do
                {
                    line = random.Next(1, 4);
                    column = random.Next(1, 4);

                } while (HasValue(board, column, line));
                column--;
                line--;
            }
            else if(board.Difficulty == Difficulty.Medium)
            {
                var selectPosition = false;
                var i = 0;
                while (!selectPosition)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        if (board.Board[i, j] == 0)
                        {
                            column = i;
                            line = j;
                            selectPosition = true;
                            break;
                        }
                    }
                    i++;
                }
            }
            else
            {

            }

            board.Board[column , line] = 2;
            board.Plays++;
            board.ShowBoard();
            board.UpdateStatusGame();
        }

        public static void UpdateStatusGame(this TicTacToeBoard board)
        {
            if (board.Plays >= 9)
            {
                board.Status = StatusGame.Draw;
                return;
            }

            //Horizontal
            for (int i = 0; i < boardSize; i++)
            {
                if (board.Board[i, 0] == board.Board[i, 1] && board.Board[i, 0] == board.Board[i, 2] && board.Board[i, 0] != 0)
                {
                    board.Status = board.Board[i, 0] == 1 ? StatusGame.PlayerWin : StatusGame.ComputerWin;
                    return;
                }
            }

            //Vertical
            for (int i = 0; i < boardSize; i++)
            {
                if (board.Board[0, i] == board.Board[1, i] && board.Board[0, i] == board.Board[2, i] && board.Board[0, i] != 0)
                {
                    board.Status = board.Board[0, i] == 1 ? StatusGame.PlayerWin : StatusGame.ComputerWin;
                    return;
                }
            }

            //Diagonal
            if(board.Board[0, 0] == board.Board[1, 1] && board.Board[0, 0] == board.Board[2, 2] && board.Board[0, 0] != 0)
            {
                board.Status = board.Board[0, 0] == 1 ? StatusGame.PlayerWin : StatusGame.ComputerWin;
                return;
            }

            if (board.Board[0, 2] == board.Board[1, 1] && board.Board[0, 2] == board.Board[2, 0] && board.Board[0, 2] != 0)
            {
                board.Status = board.Board[0, 2] == 1 ? StatusGame.PlayerWin : StatusGame.ComputerWin;
                return;
            }

            board.Status = StatusGame.InProgress;
            return;
        }

        public static void SelectDifficulty(this TicTacToeBoard board, int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    board.Difficulty = Difficulty.Easy;
                    break;
                case 2:
                    board.Difficulty = Difficulty.Medium;
                    break;
                case 3:
                    board.Difficulty = Difficulty.Hard;
                    break;
                default:
                    break;
            }
        }

        private static string ShowMove(int move)
        {
            switch (move)
            {
                case 0:
                    return "_";
                case 1:
                    return "X";
                case 2:
                    return "O";
            }
            return " ";
        }

        private static bool HasValue(this TicTacToeBoard board, int column, int line)
        {
            return board.Board[column - 1, line - 1] != 0;
        }
    }
}

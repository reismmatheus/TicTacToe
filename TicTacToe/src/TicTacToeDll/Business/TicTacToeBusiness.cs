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
            board.ShowBoard();
            board.UpdateStatusGame();
        }

        public static void PlayComputer(this TicTacToeBoard board)
        {
            var column = 0;
            var line = 0;

            do
            {
                line = random.Next(1, 4);
                column = random.Next(1, 4);

            } while (HasValue(board, column, line));

            board.Board[column - 1, line - 1] = 2;
            board.ShowBoard();
            board.UpdateStatusGame();
        }

        public static void UpdateStatusGame(this TicTacToeBoard board)
        {
            //Horizontal
            for (int i = 0; i < boardSize; i++)
            {
                if (board.Board[i, 0] == 0)
                    return;

                if (board.Board[i, 0] == board.Board[i, 1] && board.Board[i, 0] == board.Board[i, 2])
                {
                    board.Status = StatusGame.Draw;
                }
            }

            //Vertical
            for (int i = 0; i < boardSize; i++)
            {
                if (board.Board[0, i] == 0)
                    return;

                if (board.Board[0, i] == board.Board[1, i] && board.Board[0, i] == board.Board[2, i])
                {
                    board.Status = StatusGame.Draw;
                }
            }

            //Diagonal
            if (board.Board[1, 1] == 0)
                return;

            if(board.Board[0, 0] == board.Board[1, 1] && board.Board[0, 0] == board.Board[2, 2])
            {
                board.Status = StatusGame.Draw;
            }

            if (board.Board[0, 2] == board.Board[1, 1] && board.Board[0, 2] == board.Board[2, 0])
            {
                board.Status = StatusGame.Draw;
            }

            board.Status = StatusGame.Draw;
            return;
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

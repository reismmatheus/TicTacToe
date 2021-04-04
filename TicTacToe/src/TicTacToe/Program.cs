using System;
using TicTacToeDll.Business;
using TicTacToeDll.Model;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var plays = 0;

            var line = 0;
            var column = 0;

            var board = new TicTacToeBoard();

            Console.WriteLine("Who Starts: ");
            Console.WriteLine("1 - You | 2 - Computer ");
            var whoPlay = int.Parse(Console.ReadLine());

            Console.WriteLine("Select the difficulty: ");
            Console.WriteLine("1 - Easy | 2 - Medium | 3 - Hard");
            board.SelectDifficulty(int.Parse(Console.ReadLine()));

            while (plays <= 9 && board.Status == StatusGame.InProgress)
            {
                if(whoPlay == 1)
                {
                    Console.WriteLine("Your Turn");
                    Console.WriteLine("Line: ");
                    line = int.Parse(Console.ReadLine());
                    Console.WriteLine("Column: ");
                    column = int.Parse(Console.ReadLine());
                    board.PlayPlayer(line, column);
                    whoPlay = 2;
                }
                else
                {
                    Console.WriteLine("Computer Turn");
                    board.PlayComputer();
                    whoPlay = 1;
                }
            }

            Console.WriteLine($"{board.Status}");
        }
    }
}

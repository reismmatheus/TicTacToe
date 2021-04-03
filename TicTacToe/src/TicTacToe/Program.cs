using System;
using TicTacToeDll.Business;
using TicTacToeDll.Model;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = 0;
            var column = 0;

            var board = new TicTacToeBoard();

            while (board.Status == StatusGame.InProgress)
            {
                Console.WriteLine("Sua vez");

                Console.WriteLine("Digite a linha: ");
                line = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a coluna: ");
                column = int.Parse(Console.ReadLine());
                board.PlayPlayer(line, column);



                Console.WriteLine("Vez do Computador");
                board.PlayComputer();
            }

            //board.ShowBoard();
            //board.PlayPlayer(1, 3);
            //board.ShowBoard();
            //board.PlayComputer();
            //board.ShowBoard();
        }
    }
}

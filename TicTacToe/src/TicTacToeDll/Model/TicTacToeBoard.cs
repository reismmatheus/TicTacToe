using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeDll.Model
{
    public class TicTacToeBoard
    {
        public int[,] Board { get; set; } = new int[3, 3];
        public StatusGame Status { get; set; } = StatusGame.InProgress;
        public Difficulty Difficulty { get; set; } = Difficulty.Easy;
        public int Plays { get; set; }
    }

    public enum StatusGame
    {
        InProgress = 0,
        PlayerWin = 1,
        ComputerWin = 2,
        Draw = 3
    }

    public enum Difficulty
    {
        Easy = 0,
        Medium = 1,
        Hard = 2
    }
}

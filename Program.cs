using System;

namespace _07_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTakToeGame = new TicTacToeGame();
            ticTakToeGame.ChoiceOfLetter();
            ticTakToeGame.DisplayBoard();
            ticTakToeGame.Toss();
            //ticTakToeGame.UserMove();
        }
    }
}

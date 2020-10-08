using System;

namespace _07_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game!");
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.Toss();
            ticTacToeGame.ChoiceOfLetter();
            ticTacToeGame.StartGame();
            ticTacToeGame.UserMove();
        }
    }
}

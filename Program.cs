using System;

namespace _07_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game!");
            PlayGame();
        }

        static void PlayGame()
        {
            TicTacToeGame ticTacToeGame;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n********************************************************");
                Console.WriteLine("Press 1 to Start New Game!\nPress Any other key to Exit!");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ticTacToeGame = new TicTacToeGame();
                        ticTacToeGame.StartGame();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}

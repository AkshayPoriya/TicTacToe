using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Workshop
{
    public class TicTacToeGame
    {
        char[] board = new char[10];
        char humanChoice = ' ', computerChoice = ' ';

        public TicTacToeGame()
        {
            for(int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
        }

        public void ChoiceOfLetter()
        {
            Console.WriteLine("Please enter your choice!");
            Console.WriteLine("Enter 1 for X \nEnter 2 for O");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    humanChoice = 'X';
                    computerChoice = 'O';
                    break;
                case "2":
                    humanChoice = 'O';
                    computerChoice = 'X';
                    break;
                default:
                    Console.WriteLine("Wrong Input, default choice X assigned to user!");
                    humanChoice = 'X';
                    computerChoice = 'O';
                    break;
            }
            Console.WriteLine("User Choice: "+humanChoice);
            Console.WriteLine("Bot Choice: "+computerChoice);
        }

        public void DisplayBoard()
        {
            Console.WriteLine("\n"+board[1] + "|" + board[2] + "|" + board[3]);
            Console.WriteLine("------");
            Console.WriteLine(board[4] + "|" + board[5] + "|" + board[6]);
            Console.WriteLine("------");
            Console.WriteLine(board[7] + "|" + board[8] + "|" + board[9]+"\n");
        }

    }
}

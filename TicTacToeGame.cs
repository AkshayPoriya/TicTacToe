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
            //ChoiceOfLetter();
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

    }
}

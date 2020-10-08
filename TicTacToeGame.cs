using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Workshop
{
    public class TicTacToeGame
    {
        char[] board = new char[10];
        public TicTacToeGame()
        {
            for(int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
        }

    }
}

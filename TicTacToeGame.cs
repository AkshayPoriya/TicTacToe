using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Workshop
{
    public class TicTacToeGame
    {
        char[] board = new char[10];
        char humanChoice = ' ', computerChoice = ' ';
        private bool[] positionFilled = new bool[10];
        const int botFirst = 0, userFirst = 1;
        int toss;

        public TicTacToeGame()
        {
            for(int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
                positionFilled[i] = false;
            }
            positionFilled[0] = true;
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

        public void Toss()
        {
            Random random = new Random();
            int toss = random.Next(0, 2);
            if (toss == botFirst)
            {
                Console.WriteLine("\nBot Wins the toss");
            }
            else
            {
                Console.WriteLine("\nUser wins the toss");
            }
            
        }

        public void UserMove()
        {
            while (PositionAvailable())
            {
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Available Positions in Board:");
                    for (int i = 1; i < positionFilled.Length; i++)
                    {
                        if (!positionFilled[i])
                        {
                            Console.Write(i + " ");
                        }
                    }
                    Console.WriteLine("\nPlease enter your choice from above-mentioned choices");
                    int userMove = Convert.ToInt32(Console.ReadLine());
                    if (userMove >= 1 && userMove <= 9 && positionFilled[userMove])
                    {
                        Console.WriteLine("Invalid Choice, Position already filled! Enter again!");
                    }
                    else if (userMove < 1 || userMove > 9)
                    {
                        Console.WriteLine("Invalid Entry! Try Again!");
                    }
                    else
                    {
                        board[userMove] = humanChoice;
                        positionFilled[userMove] = true;
                        flag = false;
                    }
                }
                DisplayBoard();
                BotMove();
                string result = FindWinner();
                if (result == "Bot")
                {
                    Console.WriteLine("Bot Wins the Game");
                    return;
                }
                if (result == "User")
                {
                    Console.WriteLine("User Wins the Game");
                    return;
                }
                if(result == "Play")
                {
                    Console.WriteLine("Play Further!");
                }
            }
            
        }

        public void BotMove()
        {
            if (!PositionAvailable())
            {
                return;
            }
            List<int> availablePlaces = new List<int>();
            for (int i = 1; i < positionFilled.Length; i++)
            {
                if (!positionFilled[i])
                {
                    availablePlaces.Add(i);
                }
            }
            Random random = new Random();
            int cursorMovement = random.Next(0, availablePlaces.Count);
            int botMove = availablePlaces[cursorMovement];
            board[botMove] = computerChoice;
            positionFilled[botMove] = true;
            Console.WriteLine("Bot marks at: "+botMove);
            DisplayBoard();
        }

        public void StartGame()
        {
            if(toss == botFirst)
            {
                BotMove();
                UserMove();
            }
            else
            {
                UserMove();
            }
        }

        public bool PositionAvailable()
        {
            for(int i = 0; i < positionFilled.Length; i++)
            {
                if (!positionFilled[i])
                {
                    return true;
                }
            }
            return false;
        }

        public string FindWinner()
        {
            for(int i = 1; i <= 3; i++)
            {
                if(board[3*(i-1)+1] == board[3*(i-1)+2] && board[3 * (i - 1) + 2] == board[3 * (i - 1) + 3] && board[3*(i-1)+1] != ' ')
                {
                    if (board[3 * (i - 1) + 1] == humanChoice)
                        return "User";
                    else return "Bot";
                }
            }
            for (int i = 1; i <= 3; i++)
            {
                if (board[i] == board[3+i] && board[3+i] == board[6+i] && board[i] != ' ')
                {
                    if (board[i] == humanChoice)
                        return "User";
                    else return "Bot";
                }
            }
            if (board[1]==board[5] && board[5] == board[9]  && board[1]!=' ')
            {
                if (board[1] == humanChoice)
                    return "User";
                else return "Bot";
            }
            if (board[3] == board[5] && board[5] == board[7] && board[3]!=' ')
            {
                if (board[3] == humanChoice)
                    return "User";
                else return "Bot";
            }
            if (!PositionAvailable())
            {
                return "Tie";
            }
            return "Play";
        }
    }
}

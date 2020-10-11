using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Workshop
{
    public class TicTacToeGame
    {
        private char[] board = new char[10]; // board array stores the current state of game
        private char humanChoice = ' ', computerChoice = ' '; // Choice out of X or O
        private bool[] positionFilled = new bool[10]; // To know which positions are filled
        private string movesFirst = null; // moveFirst Stores which player plays first
        private Random random; // To ensure ranomness in Toss

        // Initialize new instance of TicTacToeGame, default constructor
        public TicTacToeGame()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
                positionFilled[i] = false;
            }
            positionFilled[0] = true;
            random = new Random();
        }

        // Toss to elect who moves first
        private void Toss()
        {
            try
            {
                Console.WriteLine("\n********************** TOSS **********************");
                string userCoinChoice;
                Console.WriteLine("Enter your choice for Toss!");
                Console.WriteLine("Press 1 for Head \nPress 2 for Tail");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        userCoinChoice = "Head";
                        break;
                    case "2":
                        userCoinChoice = "Tail";
                        break;
                    default:
                        Console.WriteLine("Wrong Input, default choice Head assigned to user!");
                        userCoinChoice = "Head";
                        break;
                }
                int tossIndex = random.Next(0, 2);
                string[] tossResult = { "Head", "Tail" };
                Console.WriteLine("{0} it is!", tossResult[tossIndex]);
                if (tossResult[tossIndex] == userCoinChoice)
                {
                    Console.WriteLine("User Wins the Toss\n---------------");
                    Console.WriteLine("What would you like! Move First or Second");
                    Console.WriteLine("Press 1 for First Move \nPress 2 for Second Move");
                    string moveChoice = Console.ReadLine();
                    movesFirst = (moveChoice == "1") ? "User" : "Bot";
                }
                else
                {
                    Console.WriteLine("Bot Wins the Toss");
                    movesFirst = "Bot";
                }
            }
            catch
            {
                Console.WriteLine("Something Went Wrong, Please Try Again!");
                Toss();
            }
        }

        // Choice out of X and O
        private void ChoiceOfLetter()
        {
            try {
                Console.WriteLine("\n************ Select you Choice: X or O ************");
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
                Console.WriteLine("User Choice: " + humanChoice);
                Console.WriteLine("Bot Choice: " + computerChoice);
            }
            catch
            {
                Console.WriteLine("Something Went Wrong, Please Try Again!");
                ChoiceOfLetter();
            }
        }

        // Just to demonstrate rules and positions of the board
        private void DisplayBoardInitial()
        {
            Console.WriteLine("\n************ These are the valid entries ************");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", "1", "2", "3");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", "4", "5", "6");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", "7", "8", "9");
            Console.WriteLine("     |     |      ");
        }

        // To display board and filled positions
        private void DisplayBoard()
        {
            Console.WriteLine("\n     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      \n");
        }

        // Return true if any of the position is free on board
        private bool PositionAvailable()
        {
            for (int i = 0; i < positionFilled.Length; i++)
            {
                if (!positionFilled[i])
                    return true;
            }
            return false;
        }

        // Return winner among  Bot and User. Tie if no-one wins the game. Play if game is not completed
        private string FindWinner()
        {
            for (int i = 1; i <= 3; i++)
            {
                if (board[3 * (i - 1) + 1] == board[3 * (i - 1) + 2] && board[3 * (i - 1) + 2] == board[3 * (i - 1) + 3] && board[3 * (i - 1) + 1] != ' ')
                {
                    if (board[3 * (i - 1) + 1] == humanChoice)
                        return "User";
                    else return "Bot";
                }
            }
            for (int i = 1; i <= 3; i++)
            {
                if (board[i] == board[3 + i] && board[3 + i] == board[6 + i] && board[i] != ' ')
                {
                    if (board[i] == humanChoice)
                        return "User";
                    else return "Bot";
                }
            }
            if (board[1] == board[5] && board[5] == board[9] && board[1] != ' ')
            {
                if (board[1] == humanChoice)
                    return "User";
                else return "Bot";
            }
            if (board[3] == board[5] && board[5] == board[7] && board[3] != ' ')
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

        // To take input from user to play its move
        private void UserMove()
        {
            try
            {
                if (!PositionAvailable())
                    return;
                bool flag = true;
                int userMove = 0;
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
                    userMove = Convert.ToInt32(Console.ReadLine());
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
                Console.WriteLine("\nUser marks at: " + userMove);
                DisplayBoard();
            }
            catch
            {
                Console.WriteLine("Something Went Wrong, Please Try Again!");
                UserMove();
            }
        }

        // Rules for Bot to play game
        private void BotMove()
        {
            if (!PositionAvailable())
                return;
            for (int i = 1; i < positionFilled.Length; i++)
            {
                if (!positionFilled[i])
                {
                    board[i] = computerChoice;
                    if (FindWinner() == "Bot")
                    {
                        positionFilled[i] = true;
                        Console.WriteLine("Bot marks at: " + i);
                        DisplayBoard();
                        return;
                    }
                    else
                        board[i] = ' ';
                }   
            }

            List<int> availablePlaces = new List<int>();
            for (int i = 1; i < positionFilled.Length; i++)
            {
                if (!positionFilled[i])
                {
                    availablePlaces.Add(i);
                }
            }
            int cursorMovement = random.Next(0, availablePlaces.Count);
            int botMove = availablePlaces[cursorMovement];
            board[botMove] = computerChoice;
            positionFilled[botMove] = true;
            Console.WriteLine("Bot marks at: " + botMove);
            DisplayBoard();
        }

        // This function keep calling BotMove and UserMove untill game is completed
        private void PlayTillEnd()
        {
            while (PositionAvailable())
            {
                UserMove();
                string result = FindWinner();
                if (result == "Bot")
                {
                    Console.WriteLine("Bot Wins the Game!");
                    return;
                }
                if (result == "User")
                {
                    Console.WriteLine("User Wins the Game!");
                    return;
                }
                if (result == "Tie")
                {
                    Console.WriteLine("Game Tie!");
                    return;
                }
                BotMove();
                result = FindWinner();
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
            }
        }

        // Only public function
        public void StartGame()
        {
            Toss();
            ChoiceOfLetter();
            DisplayBoardInitial();
            Console.WriteLine("\n***************** Lets Play Game *****************");
            if (movesFirst == "Bot")
            {
                BotMove();
                PlayTillEnd();
            }
            else
            {
                PlayTillEnd();
            }
        }

    }


}

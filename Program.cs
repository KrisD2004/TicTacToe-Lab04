﻿namespace TicTacToe_LAB04
{
    public class Player
    {
        public string Name;
        public string Marker;
        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }
    }

    public class Program
    {
        public static string[][] Board;
        public static Player currentPlayer;






        static void Main(string[] args)
        {
            Console.WriteLine("Hi. Lets play TicTacToe!!");
            Console.Write("Player1's name: ");
            string player1name = Console.ReadLine();
            Player player1 = new Player(player1name, "X");

            Console.Write("Player2's name: ");
            string player2name = Console.ReadLine();
            Player player2 = new Player(player2name, "O");

            Console.WriteLine("====== {0} vs {1} =====", player1.Name, player2.Name);

            Board = new string[][] {
               new string[] {"1", "2", "3"},
               new string[] {"4", "5", "6"},
               new string[] {"7", "8", "9"}
            };

            Console.WriteLine("Heres the board");
            DisplayBoard();

            Player currentPlayer = player1;
            string winner = null;
            while (winner == null)
            {
                Console.WriteLine("It's {0}'s turn!", currentPlayer.Name);

                Console.WriteLine("Please choose a slot.");
                DisplayBoard();
                string selectedSlot = Console.ReadLine();

                //Check if slot has already been selected
                bool isValid = SelectionIsValid(selectedSlot);
                if (isValid)
                {
                    int[] indexes = SelectionToIndexes(selectedSlot);
                    int row = indexes[0];
                    int column = indexes[1];
                    Board[row][column] = currentPlayer.Marker;
                }
                else
                {
                    continue;
                }

                if (currentPlayer == player1)
                {
                    currentPlayer = player2;
                }
                else if (currentPlayer == player2)
                {
                    currentPlayer = player1;
                }

                winner = CheckForWin();
                if (winner != null)
                {
                    Console.WriteLine("Congratulations, {0} wins!", winner);
                    break;
                }
            }
        }

        static void DisplayBoard()
        {
            Console.WriteLine("|{0}||{1}||{2}|", Board[0][0], Board[0][1], Board[0][2]);
            Console.WriteLine("|{0}||{1}||{2}|", Board[1][0], Board[1][1], Board[1][2]);
            Console.WriteLine("|{0}||{1}||{2}|", Board[2][0], Board[2][1], Board[2][2]);
        }
       public  static int[] SelectionToIndexes(string selectedSlot)
        {
            int[] indexes = new int[2];
            switch (selectedSlot)
            {
                case "1":
                    indexes[0] = 0;
                    indexes[1] = 0;
                    break;
                case "2":
                    indexes[0] = 0;
                    indexes[1] = 1;
                    break;
                case "3":
                    indexes[0] = 0;
                    indexes[1] = 2;
                    break;
                case "4":
                    indexes[0] = 1;
                    indexes[1] = 0;
                    break;
                case "5":
                    indexes[0] = 1;
                    indexes[1] = 1;
                    break;
                case "6":
                    indexes[0] = 1;
                    indexes[1] = 2;
                    break;
                case "7":
                    indexes[0] = 2;
                    indexes[1] = 0;
                    break;
                case "8":
                    indexes[0] = 2;
                    indexes[1] = 1;
                    break;
                case "9":
                    indexes[0] = 2;
                    indexes[1] = 2;
                    break;
            }
            return indexes;
        }
        public static bool SelectionIsValid(string selectedSlot)
        {
            bool isValid = true;
            int[] indexes = SelectionToIndexes(selectedSlot);
            int row = indexes[0];
            int column = indexes[1];
            string slotValue = Board[row][column];
            if (slotValue == "X" || slotValue == "O")
            {
                isValid = false;
            }
            if (isValid == false)
            {
                Console.WriteLine("Selection is invalid");
            }
            return isValid;
        }

        public static string CheckForWin()
        {
            // Checking the rows
            for (int row = 0; row < 3; row++)
            {
                if (Board[row][0] == Board[row][1] && Board[row][1] == Board[row][2])
                {
                    return Board[row][0];
                }
            }

            // Checking columns
            for (int col = 0; col < 3; col++)
            {
                if (Board[0][col] == Board[1][col] && Board[1][col] == Board[2][col])
                {
                    return Board[0][col];
                }
            }

            // Check diagonals
            if ((Board[0][0] == Board[1][1] && Board[1][1] == Board[2][2]) ||
                (Board[0][2] == Board[1][1] && Board[1][1] == Board[2][0]))
            {
                return Board[1][1];
            }

            // No winner
            return null;
        }

        public static void SwitchPlayers(Player player1, Player player2)
        {
            if (currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
            }
        }



    }
}
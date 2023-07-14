namespace TicTacToe_LAB04
{
    class Player
    {
        //created new class due to more than one data type

        public string Name;
        public string Marker;
        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }
    }

    internal class Program
    {
        public static string[][] Board;
        static void Main(string[] args)
        {

            Console.WriteLine("Hi! Lets play TicTacToe!!");
            Console.Write("Player 1's name: ");
            string player1name = Console.ReadLine();
            Player player1 = new Player(player1name, "X");


            Console.Write("Player 2's name: ");
            string player2name = Console.ReadLine();
            Player player2 = new Player(player2name, "O");

            Console.WriteLine("===== {0} vs {1} =====", player1.Name, player2.Name);

            Board = new string[][]
            {
                new string [] {"1", "2", "3" },
                new string [] { "4", "5", "6" },
                new string [] { "7", "8", "9" }
            };

            Console.WriteLine("Here is your board");
            DisplayBoard();


            Player currentPlayer = player1;
            string winner = null;
            while (winner == null)
            {
                Console.Write("Its {0}'s turn!", currentPlayer.Name );

                Console.WriteLine("Please choose a slot.");
                DisplayBoard();
                string selectedSlot = Console.ReadLine();

                if (selectedSlot == "1")
                {

                    Board[0][0] = currentPlayer.Marker;
                }
                else if (selectedSlot == "2")
                {
                    Board[0][1] = currentPlayer.Marker;

                }
                else if (selectedSlot == "3")
                {
                    Board[0][2] =  currentPlayer.Marker;

                }
                else if (selectedSlot == "4")
                {
                    Board[1][0] = currentPlayer.Marker;

                }
                else if (selectedSlot == "5")
                {
                    Board[1][1] = currentPlayer.Marker;

                }
                else if (selectedSlot == "6")
                {
                    Board[1][2] = currentPlayer.Marker;

                }
                else if (selectedSlot == "7")
                {
                    Board[2][0] = currentPlayer.Marker;

                }
                else if (selectedSlot == "8")
                {
                    Board[2][1] = currentPlayer.Marker;

                }
                else if (selectedSlot == "9")
                {
                    Board[2][2] = currentPlayer.Marker;

                }

                if (currentPlayer == player1)
                {
                    currentPlayer = player2;
                } else if (currentPlayer == player2)
                {
                    currentPlayer = player1;
                }

            }


        }

        static void DisplayBoard()
        {
            Console.WriteLine("|{0}||{1}||{2}|", Board[0][0], Board[0][1], Board[0][2]);
            Console.WriteLine("|{0}||{1}||{2}|", Board[1][0], Board[1][1], Board[1][2]);
            Console.WriteLine("|{0}||{1}||{2}|", Board[2][0], Board[2][1], Board[2][2]);
        }
    }
}
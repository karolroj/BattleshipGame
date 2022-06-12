using WarshipGame;
using WarshipGame.Models;

namespace WarshipGame
{
    public class WarshipStartup
    {
        static void Main()
        {
            User firstPlayer = new();
            User secondPlayer = new();

            GameBoard firstPlayerBoard = new();
            GameBoard firstPlayerMarks = new();
            GameBoard secondPlayerBoard = new();
            GameBoard secondPlayerMarks = new();

            List<Ship> firstPlayerShips = BoardActions.RenderShips(firstPlayerBoard);
            List<Ship> secondPlayerShips = BoardActions.RenderShips(secondPlayerBoard);

            while (!firstPlayer.HasWon && !secondPlayer.HasWon)
            {
                Console.WriteLine("First player board:");
                BoardActions.PrintPanel(firstPlayerBoard);

                Console.WriteLine("\n\nMark board:");
                BoardActions.PrintPanel(firstPlayerMarks);

                firstPlayer.HasWon = UserActions.ShootAndMark(secondPlayerBoard, firstPlayerMarks, secondPlayerShips);
                if(firstPlayer.HasWon)
                {
                    break;
                }    
                Console.WriteLine("Press any key to pass the turn.");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Second player board:");
                BoardActions.PrintPanel(secondPlayerBoard);

                Console.WriteLine("\n\nMark board: ");
                BoardActions.PrintPanel(secondPlayerMarks);

                secondPlayer.HasWon = UserActions.ShootAndMark(firstPlayerBoard, secondPlayerMarks, firstPlayerShips);
                if(secondPlayer.HasWon)
                {
                    break;
                }
                Console.WriteLine("Press any key to pass the turn.");
                Console.ReadKey();
                Console.Clear();
            }

            if(firstPlayer.HasWon)
            {
                Console.Write("\nFirst player wins!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nSecond player wins!");
                Console.ReadKey();
            }
        }
    }
}


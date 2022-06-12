using System.Text.RegularExpressions;
using WarshipGame.Dictionaries;
using WarshipGame.Models;
using WarshipGame.Utilities;

namespace WarshipGame
{
    public static class UserActions
    {
        public static bool ShootAndMark(GameBoard shootBoard, GameBoard markBoard, List<Ship> playerShips)
        {
            Console.Write("Enter cell(e.g. A7): ");
            string? userShoot = Console.ReadLine();

            while (!ValidateInput(userShoot))
            {
                userShoot = Console.ReadLine();
            }

            int columnShoot = Char.ToUpper(userShoot[0]) - 64;
            int rowShoot = Int32.Parse(userShoot[1].ToString());

            if(userShoot.Length == 3 && userShoot[2].ToString() != string.Empty)
            {
                rowShoot = 10;
            }

            Cell shootCell = shootBoard.boardCells[rowShoot - 1, columnShoot - 1];
            Cell markCell = markBoard.boardCells[rowShoot - 1, columnShoot - 1];

            if (shootCell.State == StateOfCell.Empty || shootCell.State == StateOfCell.BorderOfShip)
            {
                Console.WriteLine("Missed.");
                markCell.State = StateOfCell.MissedShot;

            }
            else if (shootCell.State == StateOfCell.MissedShot || shootCell.State == StateOfCell.Hit)
            {
                Console.WriteLine("You already have tried that.");
                ShootAndMark(shootBoard, markBoard, playerShips);
            }
            else if (shootCell.State == StateOfCell.Ship)
            {
                shootCell.Ship.Health--;
                if (shootCell.Ship.IsUp())
                {
                    Console.WriteLine("Hit and sink.");
                    playerShips.Remove(shootCell.Ship);
                    if (playerShips.Count == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Hit.");
                }
                shootCell.State = StateOfCell.Hit;
                markCell.State = StateOfCell.Hit;
            }
            return false;
        }

        private static bool ValidateInput(string userShoot)
        {
            Regex cellFormat = new(@"^[a-j]{1}([1-9]{1}|10)$");
            cellFormat.Options.HasFlag(RegexOptions.IgnoreCase);

            if (!cellFormat.IsMatch(userShoot))
            {
                Console.WriteLine("\nWrong input, enter column and row e.g. A10");
                return false;
            }

            return true;
        }

    }
}
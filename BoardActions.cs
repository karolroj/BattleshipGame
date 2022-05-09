using System.Drawing;
using warship.Models;
using warship.Utilities;

namespace warship
{
    public class BoardActions
    {
        public static List<Ship> RenderShips(GameBoard gameBoard)
        {
            List<Ship> ships = new()
            {
                new Carrier(),
                new Battleship(),
                new Cruiser(),
                new Submarine(),
                new Destroyer()
            };

            foreach (Ship ship in ships)
            {
                Point startingPosition = StartingPositionRnd();

                if (OrientationRnd())
                {
                    if (OrientationRnd())
                    {
                        while (((startingPosition.X + ship.Width) > 9) || IsAnotherShipOnPath(startingPosition, ship.Width, Orientation.Down, gameBoard))
                        {
                            startingPosition = StartingPositionRnd();
                        }

                        int rndRow = startingPosition.X;
                        int startingRow = startingPosition.X - 1;
                        int endingRow = startingPosition.X + ship.Width;

                        for (int i = 1; i <= ship.Width; i++)
                        {
                            SetVerticalBorder(rndRow, startingPosition.Y, gameBoard, endingRow, startingRow);
                            SetShip(rndRow, startingPosition.Y, gameBoard, ship);
                            rndRow++;
                        }
                    }
                    else
                    {
                        while ((startingPosition.X - ship.Width) < 0 || IsAnotherShipOnPath(startingPosition, ship.Width, Orientation.Up, gameBoard))
                        {
                            startingPosition = StartingPositionRnd();
                        }

                        int rndRow = startingPosition.X;
                        int startingRow = startingPosition.X + 1;
                        int endingRow = startingPosition.X - ship.Width;

                        for (int i = 1; i <= ship.Width; i++)
                        {
                            SetVerticalBorder(rndRow, startingPosition.Y, gameBoard, endingRow, startingRow);
                            SetShip(rndRow, startingPosition.Y, gameBoard, ship);
                            rndRow--;
                        }
                    }
                }
                else
                {
                    if (OrientationRnd())
                    {
                        while ((startingPosition.Y + ship.Width) > 9 || IsAnotherShipOnPath(startingPosition, ship.Width, Orientation.Right, gameBoard))
                        {
                            startingPosition = StartingPositionRnd();
                        }

                        int rndColumn = startingPosition.Y;
                        int endingColumn = startingPosition.Y + ship.Width;
                        int startingColumn = startingPosition.Y - 1;

                        for (int i = 1; i <= ship.Width; i++)
                        {
                            SetHorizontalBorder(startingPosition.X, rndColumn, gameBoard, endingColumn, startingColumn);
                            SetShip(startingPosition.X, rndColumn, gameBoard, ship);
                            rndColumn++;
                        }
                    }
                    else
                    {
                        while ((startingPosition.Y - ship.Width) < 0 || IsAnotherShipOnPath(startingPosition, ship.Width, Orientation.Left, gameBoard))
                        {
                            startingPosition = StartingPositionRnd();
                        }

                        int rndColumn = startingPosition.Y;
                        int endingColumn = startingPosition.Y - ship.Width;
                        int startingColumn = startingPosition.Y + 1;

                        for (int i = 1; i <= ship.Width; i++)
                        {
                            SetHorizontalBorder(startingPosition.X, rndColumn, gameBoard, endingColumn, startingColumn);
                            SetShip(startingPosition.X, rndColumn, gameBoard, ship);
                            rndColumn--;
                        }
                    }
                }
            }
            return ships;
        }

        private static void SetShip(int row, int column, GameBoard gameBoard, Ship ship)
        {
            Cell cellToSetup = gameBoard.boardCells[row, column];
            cellToSetup.Ship = ship;
            cellToSetup.State = StateOfCell.Ship;
        }

        private static void SetVerticalBorder(int row, int column, GameBoard gameBoard, int endingRow, int startingRow)
        {

            if (startingRow >= 0 && startingRow <= 9)
            {
                Cell beforeShipBorder = gameBoard.boardCells[startingRow, column];
                beforeShipBorder.State = StateOfCell.BorderOfShip;
            }


            if (endingRow <= 9 && endingRow >= 0)
            {
                Cell afterShipBorder = gameBoard.boardCells[endingRow, column];
                afterShipBorder.State = StateOfCell.BorderOfShip;
            }


            if((column + 1) <= 9)
            {
                Cell rightBorder = gameBoard.boardCells[row, column + 1];
                rightBorder.State = StateOfCell.BorderOfShip;
            }

            if((column -1) >= 0)
            {
                Cell leftBorder = gameBoard.boardCells[row, column - 1];
                leftBorder.State = StateOfCell.BorderOfShip;
            }
        }

        private static void SetHorizontalBorder(int row, int column, GameBoard gameBoard, int endingPosition, int startingColumn)
        {
            if (startingColumn >= 0 && startingColumn <= 9)
            {
                Cell beforeShipBorder = gameBoard.boardCells[row, startingColumn];
                beforeShipBorder.State = StateOfCell.BorderOfShip;
            }

            if (endingPosition <= 9 && endingPosition >= 0)
            {
                Cell topBorder = gameBoard.boardCells[row, endingPosition];
                topBorder.State = StateOfCell.BorderOfShip;
            }


            if ((row + 1) <= 9)
            {
                Cell topBorder = gameBoard.boardCells[row + 1, column];
                topBorder.State = StateOfCell.BorderOfShip;
            }


            if ((row - 1) >= 0)
            {
                Cell bottomBorder = gameBoard.boardCells[row - 1, column];
                bottomBorder.State = StateOfCell.BorderOfShip;
            }
        }

        private static bool IsAnotherShipOnPath(Point cellPosition, int shipWidth, Orientation orientation, GameBoard gameBoard)
        {
            for (int i = 1; i <= shipWidth; i++)
            {
                Cell cellToCheck = gameBoard.boardCells[cellPosition.X, cellPosition.Y];

                if (cellToCheck.State == StateOfCell.Ship || cellToCheck.State == StateOfCell.BorderOfShip)
                {
                    return true;
                }

                switch (orientation)
                {
                    case Orientation.Right:
                        cellPosition.Y++;
                        break;
                    case Orientation.Left:
                        cellPosition.Y--;
                        break;
                    case Orientation.Down:
                        cellPosition.X++;
                        break;
                    case Orientation.Up:
                        cellPosition.X--;
                        break;
                }
            }

            return false;
        }

        private static Point StartingPositionRnd()
        {
            Random generateRng = new();

            Point startingPosition = new()
            {
                X = generateRng.Next(0, 10),
                Y = generateRng.Next(0, 10)
            };
            return startingPosition;
        }

        private static bool OrientationRnd()
        {
            Random generateRng = new();

            bool VerticalHorizontalPosition = generateRng.Next(2) == 1;
            return VerticalHorizontalPosition;
        }

        public static void PrintPanel(GameBoard boardPrint)
        {
            Console.Write($"{string.Empty,2}");
            for (int i = 65; i < 75; i++)
            {
                Console.Write($" {Convert.ToChar(i)}");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1,2} ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"{boardPrint.boardCells[i, j].State.GetEnumDescription()} ");
                }
                Console.WriteLine();
            }
        }
    }
}

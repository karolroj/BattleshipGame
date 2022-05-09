using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warship.Models
{
    public class GameBoard
    {
        public Cell[,] boardCells = new Cell[10, 10];
        public GameBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    boardCells[i, j] = new Cell(i, j);
                }
            }
        }
    }
}

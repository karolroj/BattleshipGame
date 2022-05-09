namespace warship
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public StateOfCell State { get; set; } 
        public Ship Ship { get; set; }
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            State = StateOfCell.Empty;
        }
    }
}

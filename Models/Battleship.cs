using warship.Dictionaries;

namespace warship
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Type = ShipType.Battleship;
            Width = 4;
            Health = 4;
        }
    }
}

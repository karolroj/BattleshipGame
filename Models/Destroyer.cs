using WarshipGame.Dictionaries;

namespace WarshipGame.Models
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Type = ShipType.Destroyer;
            Width = 2;
            Health = 2;
        }
    }
}

using WarshipGame.Dictionaries;

namespace WarshipGame.Models
{
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Type = ShipType.Cruiser;
            Width = 3;
            Health = 3;
        }
    }
}

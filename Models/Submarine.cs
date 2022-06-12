using WarshipGame.Dictionaries;

namespace WarshipGame.Models
{
    public class Submarine : Ship
    {
        public Submarine()
        {
            Type = ShipType.Submarine;
            Width = 3;
            Health = 3;
        }
    }
}

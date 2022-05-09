using warship.Dictionaries;

namespace warship
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

using warship.Dictionaries;

namespace warship
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Type = ShipType.Carrier;
            Width = 5;
            Health = 5;
        }
    }
}

using warship.Dictionaries;

namespace warship
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

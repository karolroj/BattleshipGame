using warship.Dictionaries;

namespace warship
{
    public abstract class Ship
    {
        public int Width { get; set; }
        public int Health { get; set; }
        public ShipType Type { get; set; }
        public bool IsUp() => Health <= 0;
    }
}

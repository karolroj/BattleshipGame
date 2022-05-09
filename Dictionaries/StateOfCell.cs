using System.ComponentModel;

namespace warship
{
    public enum StateOfCell
    {
        [Description("O")]
        Ship,
        [Description(".")]
        Empty,
        [Description("X")]
        Hit,
        [Description("M")]
        MissedShot,
        [Description(".")]
        BorderOfShip,
    }
}

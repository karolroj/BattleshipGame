using System.ComponentModel;

namespace WarshipGame.Dictionaries
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

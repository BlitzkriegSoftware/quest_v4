namespace Blitzkrieg.QuestV4.Lib.Models
{
    public interface IMapItem
    {
        /// <summary>
        /// Player Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Player Level
        /// </summary>
        int Level { get; set; }
        /// <summary>
        /// Place in row
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Place in col
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Computed Damage
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Manu Used
        /// </summary>
        int ManaUsed { get; set; }

        int ComputeMana();

        int ComputeHitPoints();

    }
}

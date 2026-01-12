namespace Blitzkrieg.QuestV4.Lib.Models
{
    public class Enemy : IMapItem
    {
        #region "IMapItem Implementation"
        public string Name { get; set; } = "Hero";
        public int Level { get; set; } = 0;
        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public int Damage { get; set; } = 0;
        public int ManaUsed { get; set; } = 0;

        /// <summary>
        /// Compute hit points
        /// </summary>
        /// <returns></returns>
        public int ComputeHitPoints()
        {
            int hp = 0;

            return hp;
        }

        /// <summary>
        /// Compute Mana
        /// </summary>
        /// <returns>Computed Mana</returns>
        public int ComputeMana()
        {
            int mana = 0;

            return mana;
        }
        #endregion



    }
}

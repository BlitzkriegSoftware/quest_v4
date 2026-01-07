namespace Blitzkrieg.QuestV4.Lib.Models
{
    /// <summary>
    /// Event Item
    /// </summary>
    public class EventItem
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public EventItem() { }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="kind">(sic) expect 40 (potion) or 41 (scroll)</param>
        /// <param name="name">(sic)</param>
        /// <param name="duration">(sic)</param>
        /// <param name="radius">(sic)</param>
        public EventItem(int kind, string name, int duration, int radius = 0)
        {
            this.Kind = kind;
            this.Name = name;
            this.DurationRemaining = duration;
            this.Radius = radius;
        }

        /// <summary>
        /// (optional) Radius
        /// </summary>
        public int Radius { get; set; } = 0;
        /// <summary>
        /// Duration, removed once zero
        /// </summary>
        public int DurationRemaining { get; set; } = 0;
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Kind
        /// </summary>
        public int Kind { get; set; } = 0;
    }
}

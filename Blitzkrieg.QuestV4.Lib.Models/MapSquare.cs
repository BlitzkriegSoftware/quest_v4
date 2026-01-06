namespace Blitzkrieg.QuestV4.Lib.Models
{
    /// <summary>
    /// One map square
    /// </summary>
    public struct MapSquare
    {
        public char Unicode = ' ';
        public bool Visible = false;
        public int Id = 0;
        public const string SPACE = " ";

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="id"></param>
        /// <param name="unicode"></param>
        /// <param name="visible"></param>
        public MapSquare(int id, char unicode, bool visible = false)
        {
            {
                this.Id = id;
                this.Unicode = unicode;
                this.Visible = visible;
            }
        }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="id"></param>
        /// <param name="unicode"></param>
        /// <param name="visible"></param>
        public MapSquare(int id, string unicode, bool visible = false)
        {
            {
                this.Id = id;
                Unicode = string.IsNullOrEmpty(unicode) ? char.Parse(SPACE) : char.Parse(unicode);
                this.Visible = visible;
            }
        }
    }
}

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
        public MapSquare(int id, int unicode, bool visible = false)
        {
            {
                this.Id = id;
                Unicode = (unicode == 0) ? char.Parse(SPACE) : Convert.ToChar(unicode);
                this.Visible = visible;
            }
        }
    }
}

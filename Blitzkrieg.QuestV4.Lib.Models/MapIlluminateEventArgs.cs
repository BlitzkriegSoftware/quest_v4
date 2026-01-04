using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blitzkrieg.QuestV4.Lib.Models
{
    public class MapIlluminateEventArgs: EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Radius { get; set; } 
        public MapIlluminateEventArgs(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}

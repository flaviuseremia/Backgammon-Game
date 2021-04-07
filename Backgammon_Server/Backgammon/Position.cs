using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    class Position
    {
        int x, y;
        public int _x { get { return x; } set { x = value; } }

        public int _y { get { return y; } set { y = value; } }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}

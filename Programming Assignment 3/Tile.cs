using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Tile : Entity
    {

        public void render(Renderer r)
        {
            r.drawDot(pos, c);
        }
    }
}

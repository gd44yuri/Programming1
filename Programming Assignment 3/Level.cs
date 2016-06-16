using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Level
    {

        int sx, sy;

        Tile[,] t;

        public Level(int _sx, int _sy, char[,] _t)
        {
            t = new Tile[sx, sy];

            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    if (_t[x, y] == 'a')
                    {
                        
                    }
                }
            }
        }

        public void render(Renderer r)
        {
            
        }
    }
}

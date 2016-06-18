using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Level
    {

        public int sx, sy;

        public Tile[,] t;

        public Level(int _sx, int _sy)
        {
            sx = _sx;
            sy = _sy;

            t = new Tile[sx, sy];

            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    t[x, y] = new Tile(new Vector3(x, y));
                }
            }



            drawBox(new Vector3(5, 2), new Vector3(15, 11), true, 'x');
            drawBox(new Vector3(6, 3), new Vector3(13, 9), false, ' ');
            drawDot(new Vector3(5, 5), false, ' ');
        }

        public void Render(Renderer r)
        {
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    t[x, y].Render(r);
                }
            }
        }

        public void setTileAtPos(Vector3 _pos, bool solid, char c)
        {
            t[(int)_pos.x, (int)_pos.y].c = c;
            t[(int)_pos.x, (int)_pos.y].solid = solid;
        }

        //!!only run level draw methods in the constructor!!
        public void drawDot(Vector3 _pos, bool solid, char c)
        {
            setTileAtPos(new Vector3((int)(_pos.x), (int)(_pos.y)), solid, c);
            //canvas[(int)pos.x - (int)camPos.x, (int)pos.y - (int)camPos.y] = c;

        }

        //draws a box at a desired position by setting canvas chars in its range. A bit buggy
        public void drawBox(Vector3 _pos, Vector3 size, bool solid, char c)
        {
            for (int y = 0; y < size.y; y++)
                for (int x = 0; x < size.x; x++)
                    setTileAtPos(new Vector3((int)(_pos.x + x), (int)(_pos.y + y)), solid, c);
        }
    }
}

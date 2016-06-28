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
            
            //make level
            //drawBox(new Vector3(5, 2), new Vector3(15, 11), true, 'x');
            //drawBox(new Vector3(6, 3), new Vector3(13, 9), false, ' ');
            //drawDot(new Vector3(5, 5), false, ' ');

            //saveLevel();

            load();

        }

        public void setLevel(int _sx, int _sy)
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
        }

        public void load()
        {
            
            FileIO fio = new FileIO();
            fio.Read("Level_test");
            List<string> strs = fio.strings;


            int i = 0;
            foreach(string word in strs[0].Split(' ')){
                if(i == 0)
                    int.TryParse(word, out sx);
                if(i == 1)
                    int.TryParse(word, out sy);

                i++;
            }

            setLevel(sx, sy);

            strs.RemoveAt(0);

            int _y = 0;
            
            foreach(string s in strs){

                for (int x = 0; x < s.Length; x++)
                {
                    byte sld = 0;
                    if(s[x] != ' ')
                        sld = 1;

                    drawDot(new Vector3(x, _y), sld, (char)s[x]);
                }
                //Console.WriteLine(str);
                _y++;
            }
            setTile(new Door(new Vector3(10, 10)));
            setTile(new Door(new Vector3(11, 10)));
            setTile(new Door(new Vector3(12, 10)));
            setTile(new Door(new Vector3(13, 10)));


            setTile(new Door(new Vector3(23, 18)));
            setTile(new Door(new Vector3(24, 18)));
            setTile(new Door(new Vector3(25, 18)));
            setTile(new Door(new Vector3(26, 18)));
            setTile(new Door(new Vector3(23, 19)));
            setTile(new Door(new Vector3(24, 19)));
            setTile(new Door(new Vector3(25, 19)));
            setTile(new Door(new Vector3(26, 19)));

            
            //Console.Read();



        }

        //return method for
        public Tile getTileAtPos(Vector3 _pos)
        {
            return t[(int)_pos.x, (int)_pos.y];
        }

        //return method for
        public void setTile(Tile _t)
        {
            t[(int)_t.pos.x, (int)_t.pos.y] = _t;
            GC.Collect();
        }

        public void saveLevel()
        {
            List<string> strs = new List<string>();

            strs.Add(sx + " " + sy);

            for (int y = 0; y < sy; y++)
            {
                String str = "";
                for (int x = 0; x < sx; x++)
                {
                    str += t[x, y].c;
                }
                strs.Add(str);
            }

            FileIO fio = new FileIO();
            fio.Write("Level_test", strs);
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

        public List<Tile> getSurroundingTilesWithTag(Vector3 pos, string str)
        {
            List<Tile> _t = new List<Tile>();

            if (pos.x > 0 && t[(int)pos.x - 1, (int)pos.y].tag == str)
                _t.Add(t[(int)pos.x-1, (int)pos.y]);
            if (pos.x < sx - 1 && t[(int)pos.x + 1, (int)pos.y].tag == str)
                _t.Add(t[(int)pos.x+1, (int)pos.y]);

            if (pos.y > 0 && t[(int)pos.x, (int)pos.y - 1].tag == str)
                _t.Add(t[(int)pos.x, (int)pos.y-1]);
            if (pos.y < sy - 1 && t[(int)pos.x, (int)pos.y + 1].tag == str)
                _t.Add(t[(int)pos.x, (int)pos.y+1]);

            return _t;
        }

        public void setTileAtPos(Vector3 _pos, byte solid, char c)
        {
            t[(int)_pos.x, (int)_pos.y].set(c, solid);
        }

        //!!only run level draw methods in the constructor!!
        public void drawDot(Vector3 _pos, byte solid, char c)
        {
            setTileAtPos(new Vector3((int)(_pos.x), (int)(_pos.y)), solid, c);
            //canvas[(int)pos.x - (int)camPos.x, (int)pos.y - (int)camPos.y] = c;

        }

        //draws a box at a desired position by setting canvas chars in its range. A bit buggy
        public void drawBox(Vector3 _pos, Vector3 size, byte solid, char c)
        {
            for (int y = 0; y < size.y; y++)
                for (int x = 0; x < size.x; x++)
                    setTileAtPos(new Vector3((int)(_pos.x + x), (int)(_pos.y + y)), solid, c);
        }
    }
}

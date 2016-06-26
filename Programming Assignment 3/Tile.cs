using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Tile : Entity
    {

        public LivingEntity occupant;

        public Tile(Vector3 _pos)
        {
            pos = _pos;

            c = ' ';
        }

        public Tile(Vector3 _pos, char type)
        {
            pos = _pos;
            c = type;
        }

        public Tile(Vector3 _pos, char type, byte solidity)
        {
            pos = _pos;
            c = type;
            solid = solidity;
        }

        public Tile(char type, byte solidity)
        {
            c = type;
            solid = solidity;
        }

        public void set(char type, byte solidity)
        {
            c = type;
            solid = solidity;
        }

        public void setPosition(Vector3 _pos)
        {
            pos = _pos;
        }

        public void Render(Renderer r)
        {
            r.drawDot(pos, c);
        }
    }
}

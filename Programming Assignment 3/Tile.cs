using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Tile : Entity
    {


        ~Tile() { }

        public Tile(){ }

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

        //called when the player collides with this block
        public virtual void OnInteract(Game _game, bool isPartOfChain)
        {

        }

        //called when another
        public virtual void OnInteractChain(Game _game, bool isPartOfChain)
        {
            List<Tile> _t = _game._level.getSurroundingTilesWithTag(pos, tag);

            foreach (Tile ts in _t)
            {
                ts.OnInteract(_game, false);
            }
        }

        public void Render(Renderer r)
        {
            r.drawDot(pos, c);
        }
    }
}

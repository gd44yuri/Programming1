using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Door : Tile
    {

        public Door(Vector3 _pos)
        {
            pos = _pos;
            solid = 1;
            c = 'D';
            tag = "door";
        }

        //called when the player collides with this block
        public override void OnInteract(Game _game, bool isPartOfChain)
        {
            //when this interact is called 
            if (_game.keys > 0 || isPartOfChain)
            {
                //if the door is not a chained
                if (!isPartOfChain)
                    _game.keys--;//remove keys

                //set this time to a blank tile
                _game._level.setTile(new Tile(pos));
            
                //start chain
                OnInteractChain(_game, isPartOfChain);
            }
        }

        //called when an ajacent tile with the same tag is touched
        public override void OnInteractChain(Game _game,  bool isPartOfChain)
        {
            List<Tile> _t = _game._level.getSurroundingTilesWithTag(pos, tag);

            foreach (Tile ts in _t)
                ts.OnInteract(_game, true);
        }
    }
}

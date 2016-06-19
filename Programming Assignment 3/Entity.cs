using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Entity
    {
        public char c = 'x';

        public Vector3 pos = new Vector3();

        public bool solid = false;

        public bool isAlive = true;

        public Game _game;

        public Entity() { }

        public Entity(Game game) {
            _game = game;
        }

         ~Entity() { }

        public Entity(Vector3 _pos)
        {
            pos = _pos;
        }

       // public void Update()
       // {

       // }

        //public void Render()
       // {

        //}

        public void Move(Vector3 _move)
        {
            if (_game != null && pos.x + _move.x >= 0 && pos.x + _move.x < _game._level.sx && pos.y + _move.y >= 0 && pos.y + _move.y < _game._level.sy)
            {

                if (_game._level.t[(int)(pos.x + _move.x), (int)(pos.y + _move.y)] == null ||
                    _game._level.t[(int)(pos.x + _move.x), (int)(pos.y + _move.y)] != null && !_game._level.t[(int)(pos.x + _move.x), (int)(pos.y + _move.y)].solid)

                    pos.translate(_move);
                else
                    OnCollision();
            }

        }

        public virtual void OnCollision()
        {

        }

    }
}

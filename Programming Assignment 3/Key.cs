using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Key : Projectile
    {

        public Key(Vector3 _pos, string _tag)
        {
            pos = _pos;
            tag = _tag;
        }

        public override void OnDeath(Game _game)
        {
            _game.keys++;
        }

        public override void Update()
        {
        }

        public override void Render(Renderer r)
        {
            r.drawDot(this.pos, 'k');
        }
    }
}

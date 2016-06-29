using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class HealthPickup : Projectile
    {
        //this is a projectile that when touched by the player it gives the player health
        public HealthPickup(Vector3 _pos, string _tag)
        {
            pos = _pos;
            tag = _tag;
        }

        //gives the player hp on its death
        public override void OnDeath(Game _game)
        {
            _game._player.HP += 4;
        }

        public override void Render(Renderer r)
        {
            r.drawDot(this.pos, 'h');
        }
    }
}

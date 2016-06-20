using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Projectile : Entity
    {
        public byte direction;
        public char owner;
        public int power;

        public virtual void Update()
        {
        }

        public virtual void Render(Renderer r)
        {

        }
    }
}

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

        public void Move(Vector3 movement)
        {
            pos.translate(movement);
        }

        public virtual void Update()
        {
        }

        public virtual void Render(Renderer r)
        {

        }
    }
}

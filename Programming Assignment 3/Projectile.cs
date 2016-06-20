using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Projectile : Entity
    {
        //Byte to determine which direction the projectile will go
        public byte direction;
        //Char to determine what entity owns the projectile.
        public char owner;
        //Attack power for the projectile
        public int power;

        /// <summary>
        /// Base update method for Projectiles.
        /// </summary>
        public virtual void Update()
        {
        }

        /// <summary>
        /// Base Render method for Projectiles.
        /// </summary>
        /// <param name="r">Render reference</param>
        public virtual void Render(Renderer r)
        {

        }
    }
}

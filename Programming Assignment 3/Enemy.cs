using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Enemy : LivingEntity
    {
        //Boolean to control if the enemy can attack or not
        public bool canAttack;

        //Direction the enemy is facing
        public byte direction = 0;

        /// <summary>
        /// Base update method for enemies
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// Base Render method for enemies
        /// </summary>
        /// <param name="r">Render reference</param>
        public virtual void Render(Renderer r)
        {

        }
    }
}

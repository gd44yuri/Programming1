using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Enemy : LivingEntity
    {
        public bool canAttack;

        //Direction the enemy is facing
        public byte direction = 0;

        public virtual void Update()
        {

        }

        public virtual void Render(Renderer r)
        {

        }
    }
}

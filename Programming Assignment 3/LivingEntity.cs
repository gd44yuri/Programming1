using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class LivingEntity : Entity
    {
        public int HP = 10, MHP = 10;

        public Game _game;

        public void TakeDamage(int amount)
        {
            this.HP -= amount;
            if (this.HP <= 0)
            {
                //Living entity is dead
            }
        }
    }
}

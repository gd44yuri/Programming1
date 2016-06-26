using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programming_Assignment_3
{
    class LivingEntity : Entity
    {
        //Base stats for any Living Entity
        public int HP = 10, MHP = 10;
        public int attackPower = 2;

        /// <summary>
        /// Method to apply any amount of damage to a Living Entity and checking if it's now dead
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            this.HP -= amount;
            if (this.HP <= 0)
            {
                OnDeath();
            }
            else
            {
                OnHurt();
            }
        }

        /// <summary>
        /// If the Living Entity takes damage and doesn't die, this method is called
        /// </summary>
        public void OnHurt()
        {
            
        }

        /// <summary>
        /// If the Living Entity takes damage and die, this method is called. This is only the base method
        /// </summary>
        public virtual void OnDeath()
        {
            isAlive = false;
        }
    }
}

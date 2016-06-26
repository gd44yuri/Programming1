using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Programming_Assignment_3
{
    class Archer : Enemy
    {
        /// <summary>
        /// Archer enemy class constructor. Receives the position where it will spawn, the game class reference and
        /// the direction it will be facing initially.
        /// </summary>
        /// <param name="pos">Coordinates where the enemy will spawn.</param>
        /// <param name="g">Game class reference.</param>
        /// <param name="newDir">Direction the enemy will be facing initially</param>
        public Archer(Vector3 pos, Game g, byte newDir)
        {
            this.pos = pos;
            //Defining the attack power for this type of enemy.
            this.attackPower = 2;
            _game = g;
            direction = newDir;

            //Controlling the ability to attack of this enemy.
            canAttack = false;
        }

        /// <summary>
        /// Update method for the Archer class. Checks if the enemy is alive and if so takes care of calling its attack method.
        /// </summary>
        public override void Update()
        {
            if (isAlive)
            {
                AllowAttack();
                if (canAttack)
                {
                    Attack();
                    canAttack = false;
                }
            }
            //If the enemy is dead, change the canAttack variable.
            else
            {
                canAttack = false;
            }
        }

        /// <summary>
        /// Attack method that instantiate an arrow using the archer's position and its attack power.
        /// </summary>
        public void Attack()
        {
            _game.AddProjectile(new Arrow(direction, new Vector3(this.pos), 'E', this.attackPower));
            canAttack = false;
        }

        /// <summary>
        /// Render class for the Archer.
        /// </summary>
        /// <param name="r">Render reference</param>
        public override void Render(Renderer r)
        {
            r.drawDot(this.pos, 'A');
        }

        float timer;

        /// <summary>
        /// Method to control the time interval in which archers attack.
        /// </summary>
        private void AllowAttack()
        {
            if (timer >= 1)
            {
                // Task.Factory.StartNew(() =>
                // {
                canAttack = true;
                

                // });

                timer = 0;
            }
            else
                timer += 0.05f;
        }
    }
}

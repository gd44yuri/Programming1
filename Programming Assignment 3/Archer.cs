using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.canAttack = false;
        }

        /// <summary>
        /// Update method for the Archer class. Checks if the enemy is alive and if so takes care of calling its attack method.
        /// </summary>
        public override void Update()
        {
            if (isAlive)
            {
                if (this.canAttack)
                {
                    //Create a new task here to enable the use of thread.sleep and prevent attack spam.
                    Task.Factory.StartNew(() =>
                    {
                        while (isAlive)
                        {
                            //Kills the task if the enemy is not alive anymore.
                            if (!isAlive)
                            {
                                break;
                            }
                            System.Threading.Thread.Sleep(2000);
                            Attack();
                            System.Threading.Thread.Sleep(2500);
                        }

                    });
                }
                //Making sure the enemy can attack while they're alive.
                else
                {
                    this.canAttack = true;
                }
            }
            //If the enemy is dead, change the canAttack variable.
            else
            {
                this.canAttack = false;
            }
        }

        /// <summary>
        /// Attack method that instantiate an arrow using the archer's position and its attack power.
        /// </summary>
        public void Attack()
        {
            _game.AddProjectile(new Arrow(direction, new Vector3(this.pos), 'E', this.attackPower));
            this.canAttack = false;
        }

        /// <summary>
        /// Render class for the Archer.
        /// </summary>
        /// <param name="r">Render reference</param>
        public override void Render(Renderer r)
        {
            r.drawDot(this.pos, 'A');
        }
    }
}

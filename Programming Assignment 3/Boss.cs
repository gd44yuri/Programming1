using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Boss : Enemy
    {


        bool canMove = true;

        public Boss(Vector3 pos, Game g, byte newDir)
        {
            this.pos = pos;
            //Defining the attack power for this type of enemy.
            this.attackPower = 4;

            HP = 100;

            _game = g;

            direction = newDir;

            //Controlling the ability to attack of this enemy.
            canAttack = true;
        }

        int state = 0;

        float timer = 0;

        float jump = 0;

        float zVel;

        /// <summary>
        /// Update method to make the arrow move in the screen according to its direction
        /// </summary>
        public override void Update()
        {
            if (state == 0) { 
                AllowMovement();
                FollowPlayer();
                CheckCollision();

                zVel += jump;
                jump = jump*0.5f;
                zVel -= 0.25f;

                pos.z += zVel;

                if(pos.z<=0)
                {
                    pos.z = 0;
                    state = 1;
                    timer = 0;
                }
            }
            else if (state == 1)
            {
                if (timer >= 1f)
                {
                    state = 0;
                    jump = 1;
                }
                else
                    timer += 0.1f;
            }
        }

        float Movetimer = 0;

        /// <summary>
        /// Method to control the time interval in which soldiers can move.
        /// </summary>
        private void AllowMovement()
        {
            if (Movetimer >= 0.15f)
            {
                canMove = true;
                Movetimer = 0;
            }
            else
                Movetimer += 0.05f;
        }

        /// <summary>
        /// Method used to move the Soldier torwards the player
        /// </summary>
        public void FollowPlayer()
        {
            //Checks where the player is right now
            switch (direction)
            {
                case 0:
                    Move(new Vector3(0, -1));
                    break;
                case 1:
                    Move(new Vector3(1, 0));
                    break;
                case 2:
                    Move(new Vector3(0, 1));
                    break;
                case 3:
                    Move(new Vector3(-1, 0));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method called when the arrow collides with something to destroy it.
        /// </summary>
        public void CheckCollision()
        {
            //isAlive = false;
            if (_game._player.pos.x == this.pos.x && _game._player.pos.y == this.pos.y)
            {
                _game._player.TakeDamage(this.attackPower);
            }
        }

        /// <summary>
        /// Method used to check the player's position relative to the soldier and adjust the soldier's direction accordingly
        /// </summary>
        /// <param name="playerPos"></param>
        /// <returns></returns>
        public byte CheckMovement(Vector3 playerPos)
        {
            if (playerPos.x < this.pos.x)
            {
                return 3;
            }
            else if (playerPos.x > this.pos.x)
            {
                return 1;
            }
            else if (playerPos.y < this.pos.y)
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// Render class for the Archer.
        /// </summary>
        /// <param name="r">Render reference</param>
        public override void Render(Renderer r)
        {
            r.drawBox(new Vector3(pos.x-1, pos.y-2, pos.z), new Vector3(3, 3), '█');
        }
    }
}
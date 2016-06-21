using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Soldier : Enemy
    {
        Sword _sword;
        //Boolean to control the update loop
        bool isUpdate = false;
        byte updatedDir = 0;
        bool canMove = true;

        public Soldier(Vector3 pos, Game g, byte newDir)
        {
            this.pos = pos;
            //Defining the attack power for this type of enemy.
            this.attackPower = 4;

            _game = g;

            direction = newDir;

            //Controlling the ability to attack of this enemy.
            canAttack = true;

            CreateSword();
        }

        /// <summary>
        /// This creates an instance of the sword, place it with the Soldier pointing at the right direction and gives it the soldier's attack power.
        /// </summary>
        public void CreateSword() 
        {
            _sword = new Sword(this, direction, this.attackPower);
        }

        /// <summary>
        /// Update method to make the arrow move in the screen according to its direction
        /// </summary>
        public override void Update()
        {
            if (isUpdate)
            {
                AllowMovement();
                if (canMove)
                {
                    _sword.UpdateDirection(updatedDir);
                    FollowPlayer();
                    canMove = false;
                }
                isUpdate = false;
                CheckCollision();
            }
            else
            {
                isUpdate = true;
            }
        }

        /// <summary>
        /// Method to control the time interval in which soldiers can move.
        /// </summary>
        private void AllowMovement()
        {
            Task.Factory.StartNew(() =>
            {
                canMove = true;
                System.Threading.Thread.Sleep(800);
                canMove = false;

            });
        }

        /// <summary>
        /// Method used to move the Soldier torwards the player
        /// </summary>
        public void FollowPlayer()
        {
            //Checks where the player is right now
            updatedDir = CheckMovement(_game._player.pos);
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
            _sword.CheckCollision(_game._player);
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
            r.drawDot(this.pos, 'S');
            _sword.Render(r);
        }
    }
}

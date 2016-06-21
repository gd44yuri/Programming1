using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programming_Assignment_3
{
    class Sword : Projectile
    {
        //Symbols to be used as the sword, depending on the direction the soldier's facing
        protected char swordSides = '-';
        protected char swordUpDown = '|';

        //Variable to store the soldier's reference
        Soldier _soldier;

        /// <summary>
        /// Constructor for the Sword class
        /// </summary>
        /// <param name="sd">The soldier reference to which the sword is attached</param>
        /// <param name="sdDir">The direction the sword should be facing</param>
        /// <param name="pow">The attack power the sword will have</param>
        public Sword(Soldier sd, byte sdDir, int pow)
        {
            _soldier = sd;
            direction = sdDir;
            power = pow;
        }

        /// <summary>
        /// Method used to update the sword direction
        /// </summary>
        /// <param name="newDirection">New direction for the sword to point at</param>
        public void UpdateDirection(byte newDirection)
        {
            direction = newDirection;
        }

        /// <summary>
        /// Method to check if the sword is colliding with the player. If so, it applies damage to them.
        /// </summary>
        /// <param name="player">The player reference</param>
        public void CheckCollision(Player player)
        {
            if (player.pos.x == this.pos.x && player.pos.y == this.pos.y)
            {
                player.TakeDamage(this.power);
            }
        }

        /// <summary>
        /// Render method for the sword class. Based on the direction variable, it draws the sword in an adjascent tile from the soldier
        /// </summary>
        /// <param name="r"></param>
        public override void Render(Renderer r)
        {
            switch (direction)
            {
                case 0:
                    r.drawDot(new Vector3((int)_soldier.pos.x, ((int)_soldier.pos.y -1)), swordUpDown);
                    pos.x = _soldier.pos.x;
                    pos.y = _soldier.pos.y - 1;
                    break;
                case 1:
                    r.drawDot(new Vector3(((int)_soldier.pos.x + 1), (int)_soldier.pos.y), swordSides);
                    pos.x = _soldier.pos.x + 1;
                    pos.y = _soldier.pos.y;
                    break;
                case 2:
                    r.drawDot(new Vector3((int)_soldier.pos.x, ((int)_soldier.pos.y + 1)), swordUpDown);
                    pos.x = _soldier.pos.x;
                    pos.y = _soldier.pos.y + 1;
                    break;
                case 3:
                    r.drawDot(new Vector3(((int)_soldier.pos.x - 1), (int)_soldier.pos.y), swordSides);
                    pos.x = _soldier.pos.x - 1;
                    pos.y = _soldier.pos.y;
                    break;
                default:
                    break;
            }
        }
    }
}

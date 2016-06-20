using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Soldier : Enemy
    {
        Vector3 sword_pos;
        char swordSides = '-';
        char swordUpDown = '|';

        public Soldier(Vector3 pos, Game g, byte newDir)
        {
            this.pos = pos;
            sword_pos = pos;
            sword_pos.x -= 2;
            //Defining the attack power for this type of enemy.
            this.attackPower = 4;
            _game = g;
            direction = newDir;

            //Controlling the ability to attack of this enemy.
            canAttack = true;
        }

        public override void Update()
        {

        }

        /// <summary>
        /// Render class for the Archer.
        /// </summary>
        /// <param name="r">Render reference</param>
        public override void Render(Renderer r)
        {
            r.drawDot(this.pos, 'S');
            if (direction == 0 || direction == 2)
            {
                r.drawDot(sword_pos, swordUpDown);
            }
            else if (direction == 1 || direction == 3)
            {
                r.drawDot(sword_pos, swordSides);
            }
            
        }
    }
}

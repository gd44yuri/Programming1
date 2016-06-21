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
        protected char swordSides = '-';
        protected char swordUpDown = '|';
        Soldier _soldier;

        public Sword(Soldier sd, byte sdDir, int pow)
        {
            _soldier = sd;
            direction = sdDir;
            power = pow;
        }

        public void UpdateDirection(byte newDirection)
        {
            direction = newDirection;
        }

        public void CheckCollision(Player player)
        {
            if (player.pos.x == this.pos.x && player.pos.y == this.pos.y)
            {
                player.TakeDamage(this.power);
            }
        }

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

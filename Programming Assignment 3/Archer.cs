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
        public Archer(Vector3 pos, Game g, byte newDir)
        {
            this.pos = pos;
            this.attackPower = 2;
            _game = g;
            direction = newDir;
            this.canAttack = false;
        }

        public override void Update()
        {
            if (isAlive)
            {
                if (this.canAttack)
                {
                    Task.Factory.StartNew(() =>
                    {
                        while (isAlive)
                        {
                            if (!isAlive)
                            {
                                break;
                            }
                            System.Threading.Thread.Sleep(2000);
                            Attack();
                            System.Threading.Thread.Sleep(2000);
                        }

                    });
                }
                else
                {
                    this.canAttack = true;
                }
            }
            else
            {
                this.canAttack = false;
            }
        }

        public void Attack()
        {
            _game.AddProjectile(new Arrow(direction, new Vector3(this.pos), 'E', this.attackPower));
            this.canAttack = false;
        }

        public override void Render(Renderer r)
        {
            r.drawDot(this.pos, 'A');
        }
    }
}

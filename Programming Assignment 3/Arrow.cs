using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Arrow : Projectile
    {
        protected char rightArrow = '→';
        protected char leftArrow = '←';
        protected char upArrow = '↑';
        protected char downArrow = '↓';

        bool isUpdate = false;

        public Arrow(byte dir, Vector3 pos)
        {
            direction = dir;
            this.pos = pos;
        }

        public override void Update()
        {
            if (isUpdate)
            {
                switch (direction)
                {
                    case 0:
                        Move(new Vector3 (0, -1));
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
                isUpdate = false;
            }
            else
            {
                isUpdate = true;
            }
        }

        public override void OnCollision()
        {
            isAlive = false;
           // _game.projectiles.Remove(this);
        }

        public override void Render(Renderer r)
        {
            switch (direction)
            {
                case 0:
                    r.drawDot(this.pos, upArrow);
                    break;
                case 1:
                    r.drawDot(this.pos, rightArrow);
                    break;
                case 2:
                    r.drawDot(this.pos, downArrow);
                    break;
                case 3:
                    r.drawDot(this.pos, leftArrow);
                    break;
                default:
                    break;
            }
            
        }
    }
}

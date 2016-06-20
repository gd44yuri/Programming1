using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Arrow : Projectile
    {
        //Symbols for the arrows
        protected char rightArrow = '→';
        protected char leftArrow = '←';
        protected char upArrow = '↑';
        protected char downArrow = '↓';

        //Boolean to control the update loop
        bool isUpdate = false;

        /// <summary>
        /// Arrow Constructor.
        /// </summary>
        /// <param name="dir">The direction the arrow will travel</param>
        /// <param name="pos">Initial position</param>
        /// <param name="own">What entity is shooting the arrow</param>
        /// <param name="pow">How much damage will the arrow cause</param>
        public Arrow(byte dir, Vector3 pos, char own, int pow)
        {
            direction = dir;
            this.pos = pos;
            owner = own;
            power = pow;
        }

        /// <summary>
        /// Update method to make the arrow move in the screen according to its direction
        /// </summary>
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

        /// <summary>
        /// Method called when the arrow collides with something to destroy it.
        /// </summary>
        public override void OnCollision()
        {
            isAlive = false;
           // _game.projectiles.Remove(this);
        }

        /// <summary>
        /// Render method to draw the correct arrow on the screen.
        /// </summary>
        /// <param name="r">Render reference</param>
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

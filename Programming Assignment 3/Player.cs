using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Player : LivingEntity
    {
        InputListener _input;

        byte direction = 0;
        
        Vector3 p = new Vector3(12, 10);
        public Player(InputListener il)
        {
            _input = il;
        }

        public void Update()
        {
            if (_input.W)
            {
                p.translate(0, -1);
                direction = 0;
            }

            if (_input.D)
            {
                p.translate(1, 0);
                direction = 1;
            }
                
            if (_input.S)
            {
                p.translate(0, 1);
                direction = 2;
            }

            if (_input.A)
            {
                p.translate(-1, 0);
                direction = 3;
            }

            if (_input.SPACE)
            {
                Attack(direction);
            }
        }

        public void Render(Renderer r)
        {
            // Console.Write((float)GetDeltaTime()/5000f + "\n");
           // r.setCameraPosition(p);
            r.drawDot(p, 'P');
        }

        protected void Attack(byte dir)
        {
            //Instantiate an arrow using the player position and direction they're facing.
        }
    }
}

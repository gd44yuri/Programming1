using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Player : LivingEntity
    {
        Game _game;

        //Input listerner for player input verification
        InputListener _input;

        //Direction the player is facing
        byte direction = 0;
        
        //Player's position
        Vector3 playerPos = new Vector3(12, 10);

        public Player(InputListener il, Game g)
        {
            _input = il;
            _game = g;
        }

        public void Update()
        {
            if (_input.W)
            {
                playerPos.translate(0, -1);
                direction = 0;
            }

            if (_input.D)
            {
                playerPos.translate(1, 0);
                direction = 1;
            }
                
            if (_input.S)
            {
                playerPos.translate(0, 1);
                direction = 2;
            }

            if (_input.A)
            {
                playerPos.translate(-1, 0);
                direction = 3;
            }

            if (_input.SPACE)
            {
                Attack(direction, playerPos);
            }
        }

        public void Render(Renderer r)
        {
            // Console.Write((float)GetDeltaTime()/5000f + "\n");
           // r.setCameraPosition(p);
            r.drawDot(playerPos, 'P');
        }

        protected void Attack(byte dir, Vector3 pos)
        {
            _game.AddProjectile(new Arrow(dir, new Vector3(playerPos)));

            //Instantiate an arrow using the player position and direction they're facing.
        }
    }
}

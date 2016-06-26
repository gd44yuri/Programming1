using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Player : LivingEntity
    {
        //Input listerner for player input verification
        InputListener _input;

        //Direction the player is facing
        byte direction = 0;
        
        //Player's position
       // Vector3 playerPos = new Vector3(12, 10);

        //Player class constructor where we receive the input listener and the game class reference.
        public Player(InputListener il, Game g)
        {
            _input = il;
            _game = g;
        }

        /// <summary>
        /// Update method to handle player's input and update its position accordingly.
        /// </summary>
        public void Update()
        {
            if (_input.W)
            {
                Move(new Vector3(0, -1));
                direction = 0;
            }

            if (_input.D)
            {
                Move(new Vector3(1, 0));
                direction = 1;
            }
                
            if (_input.S)
            {
                Move(new Vector3(0, 1));
                direction = 2;
            }

            if (_input.A)
            {
                Move(new Vector3(-1, 0));
                direction = 3;
            }

            if (_input.UP)
                Attack(0, pos);

            if (_input.RIGHT)
                Attack(1, pos);

            if (_input.DOWN)
                Attack(2, pos);

            if (_input.LEFT)
                Attack(3, pos);
            
        }

        /// <summary>
        /// Method responsible for rendering the player on console.
        /// </summary>
        /// <param name="r">Render reference</param>
        public void Render(Renderer r)
        {
            // Console.Write((float)GetDeltaTime()/5000f + "\n");
            r.setCameraPosition(pos);
            r.drawDot(pos, 'P');
        }
        
        /// <summary>
        /// Method responsible for the player's attack. It instantiate an arrow and gives it the direction and the point of origin.
        /// </summary>
        /// <param name="dir">The direction the player is facing.</param>
        /// <param name="pos">The current position for the player.</param>
        private void Attack(byte dir, Vector3 pos)
        {
            _game.AddProjectile(new Arrow(dir, new Vector3(pos), 'P', this.attackPower));
        }

        /// <summary>
        /// Method that recovers player's health by a certain amount.
        /// </summary>
        /// <param name="amount">The amount that the player will recover.</param>
        public void RecoverHealth(int amount)
        {
            if (this.HP <= this.MHP)
            {
                this.HP += amount;
            }

            if (this.HP >= this.MHP)
            {
                this.HP = this.MHP;
            }
        }

        /// <summary>
        /// Method called when the player's health reaches 0 or below.
        /// </summary>
        public override void OnDeath()
        {
            _game.GameOver();
        }
    }
}

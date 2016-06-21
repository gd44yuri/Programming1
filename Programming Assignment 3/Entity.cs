﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    //Base class for all entities in the game.
    class Entity
    {
        //Char representing a wall.
        public char c = 'x';

        //Vector3 to store an entity's position
        public Vector3 pos = new Vector3();

        //Boolean to check if the Entity is solid
        public bool solid = false;

        //Boolean to check if the Entity is alive 
        public bool isAlive = true;

        //Reference to the game class
        public Game _game;

        public Entity() { }

        public Entity(Game game) {
            _game = game;
        }

         ~Entity() { }

        public Entity(Vector3 _pos)
        {
            pos = _pos;
        }

       // public void Update()
       // {

       // }

        //public void Render()
       // {

        //}

        //Move the Entity inside the level bounds if there's no wall where the Entity is going and checks for collision if there's a wall
        public void Move(Vector3 _move)
        {
            if (_game != null && pos.x + _move.x >= 0 && pos.x + _move.x < _game._level.sx && pos.y + _move.y >= 0 && pos.y + _move.y < _game._level.sy)
            {

                if (_game._level.t[(int)(pos.x + _move.x), (int)(pos.y + _move.y)] == null ||
                    _game._level.t[(int)(pos.x + _move.x), (int)(pos.y + _move.y)] != null && !_game._level.t[(int)(pos.x + _move.x), (int)(pos.y + _move.y)].solid)

                    pos.translate(_move);
                else
                    OnCollision();
            }

        }

        /// <summary>
        /// Base Method for Collision Checking
        /// </summary>
        public virtual void OnCollision()
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Entity
    {

        public char c = 'x';

        public Vector3 pos = new Vector3();

        public bool solid = false;

        public Entity(){}

        public Entity(Vector3 _pos)
        {
            pos = _pos;
        }

        public void Update()
        {

        }

        public void Render()
        {

        }
    }
}

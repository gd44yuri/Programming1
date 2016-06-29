using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Vector3
    {

        //this class is the coordinate variable for all game objects.

        public float x, y, z;

        public Vector3(){

        }

        public Vector3(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector3(Vector3 _pos)
        {
            x = _pos.x;
            y = _pos.y;
            z = _pos.z;
        }

        public Vector3(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void translate(int _x, int _y)
        {
            x += _x;
            y += _y;
        }

        public void translate(Vector3 _pos)
        {
            x += _pos.x;
            y += _pos.y;
            z += _pos.z;
        }
    }
}

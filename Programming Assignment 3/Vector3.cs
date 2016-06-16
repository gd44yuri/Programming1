using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Vector3
    {
        public float x, y, z;

        public Vector3(){

        }

        public Vector3(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
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

        public static float getDistance3D(Vector3 posA, Vector3 posB){
            float amt = 0;

            

            return amt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class InputListener
    {

        public bool W, A, S, D, UP, DOWN, LEFT, RIGHT;

        public void Update(){

            W = false;
            A = false;
            S = false;
            D = false;
            UP = false;
            DOWN = false;
            LEFT = false;
            RIGHT = false;

            while (Console.KeyAvailable)
            {
                ConsoleKey kc = Console.ReadKey().Key;

                if (kc == ConsoleKey.W)
                    W = true;

                if (kc == ConsoleKey.S)
                    S = true;

                if (kc == ConsoleKey.A)
                    A = true;

                if (kc == ConsoleKey.D)
                    D = true;

                if (kc == ConsoleKey.UpArrow)
                    UP = true;

                if (kc == ConsoleKey.DownArrow)
                    DOWN = true;

                if (kc == ConsoleKey.LeftArrow)
                    LEFT = true;

                if (kc == ConsoleKey.RightArrow)
                    RIGHT = true;

                Console.Clear();
            }
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }

        }
    }
}

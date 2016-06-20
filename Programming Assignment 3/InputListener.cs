using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class InputListener
    {
        //Booleans controlling if the respective key is pressed or not.
        public bool W, A, S, D, UP, DOWN, LEFT, RIGHT, SPACE;

        /// <summary>
        /// Update method that makes sure that by default no key is pressed.
        /// </summary>
        public void Update(){

            W = false;
            A = false;
            S = false;
            D = false;
            UP = false;
            DOWN = false;
            LEFT = false;
            RIGHT = false;
            SPACE = false;

            // While key press is available in the input stream...
            while (Console.KeyAvailable)
            {
                //Grabs the key the user pressed on the keyboard and set as true the corresponding boolean.
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

                if (kc == ConsoleKey.Spacebar)
                    SPACE = true;

                Console.Clear();
            }
            //Loop so it doesn't show the key pressed on the screen.
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }

        }
    }
}

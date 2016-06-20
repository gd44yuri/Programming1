using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class TitleScreen
    {
        //Game class reference
        Game _game;

        /// <summary>
        /// Constructor for the Title Screen
        /// </summary>
        /// <param name="g">Game class reference</param>
        public TitleScreen(Game g)
        {
            _game = g;
            Console.WriteLine("\\\\\\\\                             █■▄");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■████■");
            Console.WriteLine("////                             █■▀");
            Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.WriteLine("█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█");
            Console.WriteLine("█▒▒▒▄▄▄▄▒▄▄▄▒▒▒▄▄▄▒▄▒▒▒▄▒▄▄▄▄▒▄▄▄▒▒▒▒█");
            Console.WriteLine("█▒▒▒█▄▄█▒█▄▄█▒█▒▒▒▒█▄▄▄█▒█▄▄▒▒█▄▄█▒▒▒█");
            Console.WriteLine("█▒▒▒█▒▒█▒█▒▀▄▒▀▄▄▄▒█▒▒▒█▒█▄▄▄▒█ ▀▄▒▒▒█");
            Console.WriteLine("█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█");
            Console.WriteLine("█▒▒▄▄▄▒▄▒▒▒▄▒▒▄▄▄▒▒▒▄▄▄▒▒▄▄▄▄▄▒▄▒▒▒▄▒█");
            Console.WriteLine("█▒█▄▄▒▒█▄▄▄█▒█▒▒▒█▒█▒▒▒█▒▒▒█▒▒▒█▄▄▄█▒█");
            Console.WriteLine("█▒▄▄▄█▒█▒▒▒█▒▀▄▄▄▀▒▀▄▄▄▀▒▒▒█▒▒▒▒▒█▒▒▒█");
            Console.WriteLine("█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█");
            Console.WriteLine("█▒▒▒▒▒▄▄▄▒▄▒▒▒▄▒▒▄▄▄▒▒▒▄▄▄▒▒▄▄▄▄▄▒▒▒▒█");
            Console.WriteLine("█▒▒▒▒█▄▄▒▒█▄▄▄█▒█▒▒▒█▒█▒▒▒█▒▒▒█▒▒▒▒▒▒█");
            Console.WriteLine("█▒▒▒▒▄▄▄█▒█▒▒▒█▒▀▄▄▄▀▒▀▄▄▄▀▒▒▒█▒▒▒▒▒▒█");
            Console.WriteLine("█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█");
            Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            Console.WriteLine("\\\\\\\\                             █■▄");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■████■");
            Console.WriteLine("////                             █■▀");

            Console.WriteLine("PRESS ENTER TO BEGIN");

            Console.ReadLine();

            //Changes the boolean isRunning to start the game
            _game.isRunning = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class TitleScreen
    {
        Game _game;
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

            _game.isRunning = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_3
{
    class Game
    {
        private bool isRunning = true;

        Renderer _renderer;
        InputListener _input;

        float rTime;

        Level l;

        public Game()
        {

            _input = new InputListener();
            _renderer = new Renderer(this);

            GetDeltaTime();
            while(isRunning){
                GetDeltaTime();

                _input.Update();
                Update();

                _renderer.Render();
                rTime = 0;

                System.Threading.Thread.Sleep(50);
            }
        }

        public void LoadLevel()
        {
            //l = new Level(128, 128, );
        }

        static long lastTime = 0;
        static double GetDeltaTime()
        {
            long now = DateTime.Now.Ticks;
            double dT = (now - lastTime);
            lastTime = now;
            return dT;
        }

        Vector3 p = new Vector3(4, 4);

        public void Update()
        {
            if(_input.A)
                p.translate(-1, 0);
            if (_input.D)
                p.translate(1, 0);
            if (_input.W)
                p.translate(0, -1);
            if (_input.S)
                p.translate(0, 1);
        }

        public void Render(Renderer r)
        {
           // Console.Write((float)GetDeltaTime()/5000f + "\n");
            r.setCameraPosition(p);
            r.drawDot(new Vector3(4, 2), 'a');
            r.drawDot(new Vector3(1, 2), 'p');

            r.drawBox(new Vector3(5, 2), new Vector3(9, 5), 'x');
            r.drawBox(new Vector3(6, 3), new Vector3(7, 3), ' ');


            r.drawDot(p, 'e');
        }
    }
}

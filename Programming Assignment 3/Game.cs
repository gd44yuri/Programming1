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
        public static InputListener _input;
        Player _player;
        float rTime;

        Level l;

        List<Projectile> projectiles = new List<Projectile>();

        List<Enemy> enemies = new List<Enemy>();

        public Game()
        {
            _input = new InputListener();
            _renderer = new Renderer(this);
            _player = new Player(_input, this);
            AddEnemy(new Archer(new Vector3(15, 8), this, 3));

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


        public void Update()
        {
            _player.Update();

            foreach (Projectile p in projectiles)
            {
                p.Update();
            }

            foreach (Enemy e in enemies)
            {
                e.Update();
            }
        }

        public void Render(Renderer r)
        {
           // Console.Write((float)GetDeltaTime()/5000f + "\n");
            //r.setCameraPosition(p);
            //r.drawDot(new Vector3(4, 2), 'a');
            //r.drawDot(new Vector3(1, 2), 'p');

            r.drawBox(new Vector3(5, 2), new Vector3(15, 11), 'x');
            r.drawBox(new Vector3(6, 3), new Vector3(13, 9), ' ');

            _player.Render(r);

            foreach (Projectile p in projectiles)
            {
                p.Render(r);
            }

            foreach (Enemy e in enemies)
            {
                e.Render(r);
            }
        }

        public void AddProjectile(Projectile proj)
        {
            projectiles.Add(proj);
        }

        public void CheckProjectiles()
        {
            foreach (Projectile p in projectiles)
            {
                if (!p.isAlive)
                {
                    DestroyProjectile(p);
                }
            }
            List<Projectile> np = new List<Projectile>();
            foreach (Projectile p in projectiles) 
            {
                if (p != null)
                {
                    np.Add(p);
                }
            }
            projectiles = np;
        }

        public void DestroyProjectile(Projectile p)
        {
            p = null;
        }

        public void AddEnemy(Enemy en)
        {
            enemies.Add(en);
        }

        public void CheckEnemies()
        {
            foreach (Enemy e in enemies)
            {
                if (!e.isAlive)
                {
                    DestroyEnemy(e);
                }
            }
            List<Enemy> ne = new List<Enemy>();
            foreach (Enemy e in enemies)
            {
                if (e != null)
                {
                    ne.Add(e);
                }
            }
            enemies = ne;
        }

        public void DestroyEnemy(Enemy e)
        {
            e = null;
        }
    }
}

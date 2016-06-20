using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programming_Assignment_3
{
    class Game
    {
        private bool isRunning = true;

        Renderer _renderer;
        public static InputListener _input;
        Player _player;
        float rTime;

        public Level _level;

        public List<Projectile> projectiles = new List<Projectile>();

        public List<Enemy> enemies = new List<Enemy>();

        public Game()
        {
            _input = new InputListener();
            _renderer = new Renderer(this);
            _player = new Player(_input, this);
            _player.pos = new Vector3(4, 4);

            LoadLevel();

            AddEnemy(new Archer(new Vector3(15, 8), this, 1));

            FileIO fio = new FileIO();

            List<string> f = new List<string>();
            f.Add("yee");
            f.Add("yee2");
            f.Add("yee16");
            f.Add("yee3");

            fio.Write("asfas", f);


            fio.Read("asfas");

            /*
            //GetDeltaTime();
            while(isRunning){

                GetDeltaTime();
                _input.Update();
                Update();
                _renderer.Render();
                rTime = 0;

                System.Threading.Thread.Sleep(50);
            }*/
        }

        public void LoadLevel()
        {
            _level = new Level(128, 128);
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

            CheckProjectiles();

            CheckEnemies();

            CheckProjectilesForCollision();

            foreach (Projectile p in projectiles.Reverse<Projectile>())
            {
                if(p!=null)
                p.Update();
            }

            foreach (Enemy e in enemies)
            {
                e.Update();
            }
        }

        public void Render(Renderer r)
        {
            _level.Render(r);

            _player.Render(r);

            CheckProjectiles();

            CheckEnemies();

            foreach (Projectile p in projectiles.Reverse<Projectile>())
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
            proj._game = this;
        }

        public void CheckProjectiles()
        {
            List<Projectile> np = new List<Projectile>();
            foreach (Projectile p in projectiles.Reverse<Projectile>()) 
            {
                if (p != null)
                {
                    if (p.isAlive)
                    {
                        np.Add(p);
                    }
                }
            }

            projectiles = np;

            GC.Collect();
        }

        public void DestroyProjectile(Projectile p)
        {
            p.isAlive = false;
            projectiles.Remove(p);
        }

        public void CheckProjectilesForCollision()
        {
            List<Projectile> np = new List<Projectile>();
            np = projectiles;
            foreach (Projectile p in np.Reverse<Projectile>())
            {
                if (p.owner == 'P')
                {
                    foreach (Enemy e in enemies.Reverse<Enemy>())
                    {
                        if (p.pos.x == e.pos.x && p.pos.y == e.pos.y)
                        {
                            
                            e.TakeDamage(_player.attackPower);
                            DestroyProjectile(p);
                        }
                    }
                }
            }
        }

        public void AddEnemy(Enemy en)
        {
            enemies.Add(en);
        }

        public void CheckEnemies()
        {
            List<Enemy> ne = new List<Enemy>();
            foreach (Enemy e in enemies)
            {
                if (e != null)
                {
                    if (e.isAlive)
                    {
                        ne.Add(e);
                    }
                }
            }
            enemies = ne;
        }

        public void DestroyEnemy(Enemy e)
        {
            e.isAlive = false;
            e.canAttack = false;
            enemies.Remove(e);
        }
    }
}
